using DH.Core.Domain.Localization;

using Pek;
using Pek.Events;
using Pek.NCubeUI.Events;

namespace Test.AMapWeb.Events;

/// <summary>
/// 菜单消费
/// </summary>
public class InstallConsumer : IConsumer<InstallEvent>
{
    public Int32 Sort { get; set; } = 0;

    public async Task HandleEventAsync(InstallEvent eventMessage)
    {
        DHSetting.Current.IsAllowUrlSuffix = true;

        DHSetting.Current.IsAlertOrCheckCode = 2;
        DHSetting.Current.AdminArea = "Biz";
        DHSetting.Current.CaptChaUrl = "/CaptCha/GetCheckCode";
        DHSetting.Current.SitemapXmlEnabled = true;
        DHSetting.Current.StartTime = DateTime.Now;
        DHSetting.Current.PaswordStrength = "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,32}$";
        DHSetting.Current.UserCenterUrl = "~/Member";
        DHSetting.Current.SessionTimeout = 7200;

        DHSetting.Current.Save();

        LocalizationSettings.Current.AutomaticallyDetectLanguage = true;
        LocalizationSettings.Current.Save();
    }
}