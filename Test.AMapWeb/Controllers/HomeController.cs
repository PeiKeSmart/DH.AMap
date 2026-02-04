using Microsoft.AspNetCore.Mvc;

using Pek.NCube;

namespace Test.AMapWeb.Controllers;

/// <summary>主页面</summary>
public class HomeController : PekBaseControllerX
{
    /// <summary>主页面</summary>
    /// <returns></returns>
    public ActionResult Index()
    {
        ViewBag.Message = "高德地图代理测试";

        return PekView();
    }

    /// <summary>API测试页面</summary>
    /// <returns></returns>
    public ActionResult ApiTest()
    {
        return PekView();
    }

    /// <summary>地理编码测试页面</summary>
    /// <returns></returns>
    public ActionResult GeoCode()
    {
        return PekView();
    }

    /// <summary>逆地理编码测试页面</summary>
    /// <returns></returns>
    public ActionResult ReverseGeoCode()
    {
        return PekView();
    }

    /// <summary>错误</summary>
    /// <returns></returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error");
    }
}
