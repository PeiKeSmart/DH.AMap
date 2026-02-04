using System.ComponentModel;

using NewLife.Configuration;

using XCode.Configuration;

namespace Test.AMapWeb.Common;

/// <summary>HTTP相关默认值设置</summary>
[DisplayName("HTTP相关默认值设置")]
[Config("Pek")]
public class PekSettings : Config<PekSettings>
{
    #region 静态
    /// <summary>指向数据库参数字典表</summary>
    static PekSettings() => Provider = new DbConfigProvider { UserId = 0, Category = "DH" };
    #endregion

    /// <summary>
    /// 在客户浏览器地址栏中启用博客 RSS feeds 链接
    /// </summary>
    [Description("在客户浏览器地址栏中启用博客 RSS feeds 链接")]
    public Boolean ShowHeaderRssUrl { get; set; }
}
