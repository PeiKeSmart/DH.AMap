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
    /// 高德地图 Key（必填）
    /// </summary>
    [Description("高德地图 Key")]
    public String? AMapKey { get; set; }

    /// <summary>
    /// 高德地图私钥（可选，Web 服务 API 需要）
    /// </summary>
    [Description("高德地图私钥")]
    public String? AMapSecret { get; set; }

    /// <summary>
    /// 是否启用数字签名验证（默认 true）
    /// </summary>
    [Description("是否启用数字签名验证")]
    public Boolean EnableSignature { get; set; } = true;
    #endregion

    #region 方法
    /// <summary>计算请求签名</summary>
    /// <param name="url">请求 URL（不含协议和域名，如：/v3/geocode/geo?address=北京&key=xxx）</param>
    /// <returns>签名字符串</returns>
    public String? CalculateSignature(String url)
    {
        if (!EnableSignature || String.IsNullOrEmpty(AMapSecret)) return null;

        // 使用 MD5 计算签名：MD5(请求路径 + 私钥)
        var signString = url + AMapSecret;
        using var md5 = MD5.Create();
        var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(signString));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
    }
    #endregion
}