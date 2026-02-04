using Microsoft.AspNetCore.Http.Features;

using NewLife.Caching;
using NewLife.Caching.Services;
using NewLife.Cube;
using NewLife.Cube.WebMiddleware;
using NewLife.Log;
using NewLife.Model;

using Pek;
using Pek.Configs;
using Pek.Helpers;
using Pek.Infrastructure;

XTrace.UseConsole();

ApplicationHelper.SetEnvironment(args);

var builder = WebApplication.CreateBuilder(args);

// 清除默认日志提供程序并设置最低日志级别
builder.Logging.AddXLog(); // 添加自定义日志提供程序

ConfigFileHelper.SetConfig(builder.Configuration); //可在Settings文件夹中放入多个配置文件
builder.Configuration.AddEnvironmentVariables();

builder.Host.UseDefaultServiceProvider(options =>
{
    // 我们不验证范围，因为在应用程序启动和初始配置时，我们需要通过根容器解析某些服务（注册为 "scoped"）
    options.ValidateScopes = false;
    options.ValidateOnBuild = true;
});

var services = builder.Services;

// 引入星尘，设置监控中间件
var star = services.AddStardust(null!);
TracerMiddleware.Tracer = star?.Tracer;
star?.SetWatchdog(120);

// 分布式服务，使用配置中心RedisCache配置
ObjectContainer.Current.AddSingleton<ICacheProvider, RedisCacheProvider>();

// 修改上传的文件大小限制
DHSetting.Current.MaxSize = 200;
DHSetting.Current.CurrentVersion = "1.0.0"; // 设置当前版本
DHSetting.Current.IsInstalled = true; // 设置已安装
DHSetting.Current.Save();

// 修改上传的文件大小限制
if (!ApplicationHelper.IsIIS)
{
    // 配置上传文件大小限制（详细信息：FormOptions） IIS不在这里配置
    builder.Services.Configure<FormOptions>(o =>
    {
        o.MultipartBodyLengthLimit = DHSetting.Current.MaxSize * 1024 * 1024;
    });
}
else
{
    builder.WebHost.UseIISIntegration();
}

builder.Services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
    options.MaxRequestBodySize = DHSetting.Current.MaxSize * 1024 * 1024;
});

builder.Services.AddCube(builder.Configuration, builder.Environment);

services.AddAllSingletons(); // 注册所有单例服务

var app = builder.Build();

app.UseCube(builder.Environment);

app.UseAuthentication();  // 认证中间件 用于Jwt检验
app.UseAuthorization(); // 授权中间件

app.UsePekEndpoints(); // 注册 Pek 的路由端点

app.RegisterService("Test.AMapWeb", null, builder.Environment.EnvironmentName, "/pek/info");

app.Run();
