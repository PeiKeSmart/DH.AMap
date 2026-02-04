using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

using NewLife;

using Pek;
using Pek.NCube;
using Pek.NCube.Routing;
using Pek.NCubeUI.MVC;
using Pek.NCubeUI.MVC.Routing;

using Test.AMapWeb.Entity;

namespace Test.AMapWeb.Common;

/// <summary>
/// 代表应用程序内部构建特定 URL 的辅助实现
/// </summary>
public class PekUrlHelper : IPekUrlHelper
{
    protected readonly IUrlHelperFactory _urlHelperFactory;
    protected readonly IActionContextAccessor _actionContextAccessor;

    public PekUrlHelper(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
    {
        _urlHelperFactory = urlHelperFactory;
        _actionContextAccessor = actionContextAccessor;
    }

    /// <summary>
    /// 生成指定实体类型和路由值的通用 URL
    /// </summary>
    /// <typeparam name="TEntity">支持 slug 的实体类型</typeparam>
    /// <param name="values">一个包含路由值的对象</param>
    /// <param name="protocol">URL 协议，例如 "http" 或 "https"</param>
    /// <param name="host">URL 的主机名</param>
    /// <param name="fragment">URL 的片段</param>
    /// <returns>一个表示异步操作的任务  任务结果包含生成的 URL</returns>
    public async Task<String?> RouteGenericUrlAsync<TEntity>(object? values = null, string? protocol = null, string? host = null, string? fragment = null) where TEntity : BasePekModel, ISlugSupported
    {
        await Task.CompletedTask.ConfigureAwait(false);

        var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext!);

        var routeValues = new RouteValueDictionary(values);

        return typeof(TEntity) switch
        {
            var entityType when entityType == typeof(SingleArticle) => urlHelper.RouteUrl("MuliAbout", routeValues, protocol, host, fragment),
            var entityType => urlHelper.RouteUrl(entityType.Name, routeValues, protocol, host, fragment)
        };
    }

    /// <summary>
    /// 生成指定实体类型和路由值的通用 URL
    /// </summary>
    /// <typeparam name="TEntity">支持 slug 的实体类型</typeparam>
    /// <param name="values">一个包含路由值的对象</param>
    /// <param name="protocol">URL 协议，例如 "http" 或 "https"</param>
    /// <param name="host">URL 的主机名</param>
    /// <param name="fragment">URL 的片段</param>
    /// <returns>一个表示异步操作的任务  任务结果包含生成的 URL</returns>
    public String? RouteGenericUrl<TEntity>(object? values = null, string? protocol = null, string? host = null, string? fragment = null) where TEntity : BasePekModel, ISlugSupported
    {
        var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext!);

        var routeValues = new RouteValueDictionary(values);

        return typeof(TEntity) switch
        {
            var entityType when entityType == typeof(SingleArticle) => urlHelper.RouteUrl("MuliAbout", routeValues, protocol, host, fragment),
            var entityType => urlHelper.RouteUrl(entityType.Name, routeValues, protocol, host, fragment)
        };
    }

    /// <summary>
    /// 生成指定实体类型和路由值的通用 URL
    /// </summary>
    /// <typeparam name="TEntity">实体类型支持 slug</typeparam>
    /// <param name="routerName">路由名称</param>
    /// <param name="values">一个包含路由值的对象</param>
    /// <param name="protocol">URL 的协议，例如"http"或"https"。</param>
    /// <param name="host">URL 的主机名</param>
    /// <param name="fragment">URL 的片段</param>
    /// <param name="CurrentLanguage">当前语言</param>
    /// <returns>
    /// 一个表示异步操作的任务
    /// 任务结果包含生成的 URL
    /// </returns>
    public async Task<String?> RouteGenericUrlAsync<TEntity>(String routerName, String? CurrentLanguage = null, Object? values = null, String? protocol = null, String? host = null, String? fragment = null) where TEntity : BasePekModel, ISlugSupported
    {
        await Task.CompletedTask.ConfigureAwait(false);

        var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext!);

        var routeValues = new RouteValueDictionary(values);

        var url = typeof(TEntity) switch
        {
            var entityType when entityType == typeof(SingleArticle) => urlHelper.RouteUrl(routerName, routeValues, protocol, host, fragment),
            var entityType => urlHelper.RouteUrl(entityType.Name, routeValues, protocol, host, fragment)
        };

        if (!CurrentLanguage.IsNullOrWhiteSpace())
        {
            url = url?.Replace($"/{CurrentLanguage}", "");
        }

        return url;
    }

    /// <summary>
    /// 生成指定实体类型和路由值的通用 URL
    /// </summary>
    /// <typeparam name="TEntity">实体类型支持 slug</typeparam>
    /// <param name="routerName">路由名称</param>
    /// <param name="values">一个包含路由值的对象</param>
    /// <param name="protocol">URL 的协议，例如"http"或"https"。</param>
    /// <param name="host">URL 的主机名</param>
    /// <param name="fragment">URL 的片段</param>
    /// <param name="CurrentLanguage">当前语言</param>
    /// <returns>
    /// 一个表示异步操作的任务
    /// 任务结果包含生成的 URL
    /// </returns>
    public String? RouteGenericUrl<TEntity>(String routerName, String? CurrentLanguage = null, Object? values = null, String? protocol = null, String? host = null, String? fragment = null) where TEntity : BasePekModel, ISlugSupported
    {
        var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext!);

        var routeValues = new RouteValueDictionary(values);

        var url = typeof(TEntity) switch
        {
            var entityType when entityType == typeof(SingleArticle) => urlHelper.RouteUrl(routerName, routeValues, protocol, host, fragment),
            var entityType => urlHelper.RouteUrl(entityType.Name, routeValues, protocol, host, fragment)
        };

        if (!CurrentLanguage.IsNullOrWhiteSpace())
        {
            url = url?.Replace($"/{CurrentLanguage}", "");
        }

        return url;
    }

    /// <summary>
    /// 生成指定系统名称的主题 URL
    /// </summary>
    /// <param name="systemName">主题系统名称</param>
    /// <param name="protocol">URL 协议，例如 "http" 或 "https"</param>
    /// <param name="host">URL 的主机名</param>
    /// <param name="fragment">URL 的片段</param>
    /// <returns></returns>
    public async Task<String?> RouteTopicUrlAsync(string systemName, string? protocol = null, string? host = null, string? fragment = null)
    {
        await Task.CompletedTask.ConfigureAwait(false);

        return String.Empty;
    }

    /// <summary>
    /// 生成指定系统名称的主题 URL
    /// </summary>
    /// <param name="systemName">主题系统名称</param>
    /// <param name="protocol">URL 协议，例如 "http" 或 "https"</param>
    /// <param name="host">URL 的主机名</param>
    /// <param name="fragment">URL 的片段</param>
    /// <returns></returns>
    public String? RouteTopicUrl(string systemName, string? protocol = null, string? host = null, string? fragment = null)
    {
        return String.Empty;
    }

    /// <summary>
    /// 生成一个指定 <paramref name="routeName"/> 的绝对路径 URL。
    /// </summary>
    /// <param name="helper"><请参阅 cref="IUrlHelper"/>。</param>
    /// <param name="routeName">路由名称，用于生成 URL。</param>
    /// <param name="CurrentLanguage">当前语言</param>
    /// <returns>生成的 URL</returns>
    public async Task<String?> PekRouteUrlAsync(IUrlHelper helper, String? routeName, String? CurrentLanguage = null)
    {
        await Task.CompletedTask.ConfigureAwait(false);

        var url = helper.RouteUrl(routeName);

        if (!CurrentLanguage.IsNullOrWhiteSpace())
        {
            url = url?.Replace($"/{CurrentLanguage}", "");
        }

        return url;
    }

    /// <summary>
    /// 生成一个指定 <paramref name="routeName"/> 的绝对路径 URL。
    /// </summary>
    /// <param name="helper"><请参阅 cref="IUrlHelper"/>。</param>
    /// <param name="routeName">路由名称，用于生成 URL。</param>
    /// <param name="CurrentLanguage">当前语言</param>
    /// <returns>生成的 URL</returns>
    public String? PekRouteUrl(IUrlHelper helper, String? routeName, String? CurrentLanguage = null)
    {
        var url = helper.RouteUrl(routeName);

        if (!CurrentLanguage.IsNullOrWhiteSpace())
        {
            url = url?.Replace($"/{CurrentLanguage}", "");
        }

        return url;
    }

    /// <summary>
    /// 生成一个指定 <paramref name="routeName"/> 的绝对路径 URL。
    /// </summary>
    /// <param name="helper"><请参阅 cref="IUrlHelper"/>。</param>
    /// <param name="routeName">路由名称，用于生成 URL。</param>
    /// <param name="CurrentLanguage">当前语言</param>
    /// <param name="values">一个包含路由值的对象</param>
    /// <returns>生成的 URL</returns>
    public async Task<String?> PekRouteUrlAsync(IUrlHelper helper, String? routeName, String? CurrentLanguage = null, Object? values = null)
    {
        await Task.CompletedTask.ConfigureAwait(false);

        var url = helper.RouteUrl(routeName, values);

        if (!CurrentLanguage.IsNullOrWhiteSpace())
        {
            url = url?.Replace($"/{CurrentLanguage}", "");
        }

        return url;
    }

    /// <summary>
    /// 生成一个指定 <paramref name="routeName"/> 的绝对路径 URL。
    /// </summary>
    /// <param name="helper"><请参阅 cref="IUrlHelper"/>。</param>
    /// <param name="routeName">路由名称，用于生成 URL。</param>
    /// <param name="CurrentLanguage">当前语言</param>
    /// <param name="values">一个包含路由值的对象</param>
    /// <returns>生成的 URL</returns>
    public String? PekRouteUrl(IUrlHelper helper, String? routeName, String? CurrentLanguage = null, Object? values = null)
    {
        var routeValues = values != null ? new RouteValueDictionary(values) : [];

        // 如果未提供语言代码，则添加当前语言
        if (!routeValues.ContainsKey(PekRoutingDefaults.RouteValue.Language))
        {
            var _workContext = Pek.Webs.HttpContext.Current.RequestServices.GetRequiredService<IWorkContext>();
            if (_workContext?.WorkingLanguage != null)
            {
                routeValues[PekRoutingDefaults.RouteValue.Language] = _workContext.WorkingLanguage.UniqueSeoCode;
            }
        }

        var url = helper.RouteUrl(routeName, routeValues);

        if (!CurrentLanguage.IsNullOrWhiteSpace())
        {
            url = url?.Replace($"/{CurrentLanguage}", "");
        }

        return url;
    }
}