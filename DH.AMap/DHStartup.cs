using System.Text;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NewLife;
using NewLife.Log;

using Pek.Infrastructure;
using Pek.VirtualFileSystem;

namespace DH.AMap;

/// <summary>
/// 代表用于在应用程序启动时配置框架的对象
/// </summary>
public class DHStartup : IPekStartup
{
    /// <summary>
    /// 添加并配置任何中间件
    /// </summary>
    /// <param name="services">服务描述符集合</param>
    /// <param name="configuration">应用程序的配置</param>
    /// <param name="webHostEnvironment">应用程序的环境</param>
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {

    }

    /// <summary>
    /// 配置添加的中间件的使用
    /// </summary>
    /// <param name="application">用于配置应用程序的请求管道的生成器</param>
    public void Configure(IApplicationBuilder application)
    {

    }

    /// <summary>
    /// 配置虚拟文件系统
    /// </summary>
    /// <param name="options">虚拟文件配置</param>
    public void ConfigureVirtualFileSystem(DHVirtualFileSystemOptions options)
    {
    }

    /// <summary>
    /// 注册路由
    /// </summary>
    /// <param name="endpoints">路由生成器</param>
    public void UseDHEndpoints(IEndpointRouteBuilder endpoints)
    {
        XTrace.WriteLine("配置高德地图反向代理路由");
        // 高德地图反向代理

        // JavaScript API 加载地址代理（使用 key 参数，不需要签名）
        endpoints.Map("/_AMapService/maps", async context =>
        {
            await ProxyRequest(context, "https://webapi.amap.com/maps", "/_AMapService/", "key", false).ConfigureAwait(false);
        });
        
        // 地图样式接口（使用 key 参数，需要签名）
        endpoints.Map("/_AMapService/v4/map/styles", async context =>
        {
            await ProxyRequest(context, "https://webapi.amap.com/v4/map/styles", "/_AMapService/", "key", true).ConfigureAwait(false);
        });

        // 矢量地图接口（使用 key 参数，需要签名）
        endpoints.Map("/_AMapService/v3/vectormap", async context =>
        {
            await ProxyRequest(context, "https://fmap01.amap.com/v3/vectormap", "/_AMapService/", "key", true).ConfigureAwait(false);
        });

        // Web 服务 API（使用 key 参数，需要签名）
        endpoints.Map("/_AMapService/{**path}", async context =>
        {
            await ProxyRequest(context, "https://restapi.amap.com/", "/_AMapService/", "key", true).ConfigureAwait(false);
        });
    }

    private async Task ProxyRequest(HttpContext context, String targetUrl, String replaceUrl, String keyParamName = "key", Boolean needSignature = true)
    {
        var queryString = context.Request.QueryString;
        
        // 添加 key 参数
        var newQueryString = queryString.Add(keyParamName, AMapSetting.Current.AMapKey ?? String.Empty);

        // 构建请求路径（用于签名计算）
        var requestPath = context.Request.Path.Value?.Replace(replaceUrl, "") ?? String.Empty;
        var fullPath = requestPath + newQueryString.ToString();

        // 如果需要签名，添加 sig 参数
        if (needSignature && AMapSetting.Current.EnableSignature)
        {
            var signature = AMapSetting.Current.CalculateSignature(fullPath);
            if (!String.IsNullOrEmpty(signature))
            {
                newQueryString = newQueryString.Add("sig", signature);
            }
        }

        var targetUrlWithQueryString = targetUrl + requestPath + newQueryString;

        using var client = new HttpClient();
        var method = context.Request.Method;

        if (method.EqualIgnoreCase("GET"))
        {
            var response = await client.GetAsync(targetUrlWithQueryString).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                context.Response.ContentType = response.Content.Headers.ContentType?.ToString();
                await context.Response.WriteAsync(content).ConfigureAwait(false);
            }
            else
            {
                context.Response.StatusCode = (Int32)response.StatusCode;
            }
        }
        else if (method.EqualIgnoreCase("POST"))
        {
            using var reader = new StreamReader(context.Request.Body, Encoding.UTF8);
            var requestBody = await reader.ReadToEndAsync().ConfigureAwait(false);

            // 使用 HttpClient 发送 POST 请求
            using var httpClient = new HttpClient();
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(targetUrlWithQueryString, content).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var content1 = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                context.Response.ContentType = response.Content.Headers.ContentType?.ToString();
                await context.Response.WriteAsync(content1).ConfigureAwait(false);
            }
            else
            {
                context.Response.StatusCode = (Int32)response.StatusCode;
            }
        }
        else
        {

        }
    }

    /// <summary>
    /// 将区域路由写入数据库
    /// </summary>
    public void ConfigureArea()
    {

    }

    /// <summary>
    /// 调整菜单
    /// </summary>
    public void ChangeMenu()
    {

    }

    /// <summary>
    /// 升级处理逻辑
    /// </summary>
    public void Update()
    {

    }

    /// <summary>
    /// 配置使用添加的中间件
    /// </summary>
    /// <param name="application">用于配置应用程序的请求管道的生成器</param>
    public void ConfigureMiddleware(IApplicationBuilder application)
    {

    }

    /// <summary>
    /// UseRouting前执行的数据
    /// </summary>
    /// <param name="application"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void BeforeRouting(IApplicationBuilder application)
    {

    }

    /// <summary>
    /// UseAuthentication或者UseAuthorization后面 Endpoints前执行的数据
    /// </summary>
    /// <param name="application"></param>
    public void AfterAuth(IApplicationBuilder application)
    {

    }

    /// <summary>
    /// 处理数据
    /// </summary>
    public void ProcessData()
    {

    }

    /// <summary>
    /// 获取此启动配置实现的顺序
    /// </summary>
    public Int32 StartupOrder => 300;

    /// <summary>
    /// 获取此启动配置实现的顺序。主要针对ConfigureMiddleware、UseRouting前执行的数据、UseAuthentication或者UseAuthorization后面 Endpoints前执行的数据
    /// </summary>
    public Int32 ConfigureOrder => 0;
}