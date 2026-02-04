using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

using NewLife.Configuration;

namespace DH.AMap;

/// <summary>高德地图设置</summary>
[DisplayName("高德地图设置")]
[Config("AMapSetting")]
public class AMapSetting : Config<AMapSetting>
{
    #region 属性
    /// <summary>
    /// Web 端（JS API）Key - 用于 JavaScript API 地图加载（必填）
    /// </summary>
    [Description("Web 端（JS API）Key")]
    public String? WebKey { get; set; }

    /// <summary>
    /// Web 端（JS API）安全密钥 - 用于加强安全性（必填）
    /// </summary>
    [Description("Web 端安全密钥（JsCode）")]
    public String? WebJsCode { get; set; }

    /// <summary>
    /// Web 服务 Key - 用于 REST API（地理编码、逆地理编码等）（必填）
    /// </summary>
    [Description("Web 服务 Key")]
    public String? ServiceKey { get; set; }
    #endregion
}