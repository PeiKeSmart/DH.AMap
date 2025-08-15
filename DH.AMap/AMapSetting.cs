using System.ComponentModel;

using NewLife.Configuration;

namespace DH.AMap;

/// <summary>高德地图设置</summary>
[DisplayName("高德地图设置")]
[Config("AMapSetting")]
public class AMapSetting : Config<AMapSetting>
{
    /// <summary>
    /// 高德地图密钥
    /// </summary>
    [Description("高德地图密钥")]
    public String? AMapSecret { get; set; }
}