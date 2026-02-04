using Microsoft.AspNetCore.Mvc;

namespace Test.AMapWeb.Controllers;

/// <summary>主页面</summary>
public class HomeController : Controller
{
    /// <summary>主页面</summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        ViewBag.Title = "首页";
        ViewBag.Message = "高德地图代理测试";

        return View();
    }

    /// <summary>API测试页面</summary>
    /// <returns></returns>
    public IActionResult ApiTest()
    {
        ViewBag.Title = "JavaScript API 测试";
        return View();
    }

    /// <summary>地理编码测试页面</summary>
    /// <returns></returns>
    public IActionResult GeoCode()
    {
        ViewBag.Title = "地理编码测试";
        return View();
    }

    /// <summary>逆地理编码测试页面</summary>
    /// <returns></returns>
    public IActionResult ReverseGeoCode()
    {
        ViewBag.Title = "逆地理编码测试";
        return View();
    }

    /// <summary>错误</summary>
    /// <returns></returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}
