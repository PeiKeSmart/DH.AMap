using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Test.AMapWeb.Entity;

/// <summary>上传文件表</summary>
public partial interface IUploadInfo
{
    #region 属性
    /// <summary>编号</summary>
    Int32 Id { get; set; }

    /// <summary>上传实际文件名</summary>
    String? OriginFileName { get; set; }

    /// <summary>上传文件名</summary>
    String? FileName { get; set; }

    /// <summary>上传文件大小</summary>
    Int64 FileSize { get; set; }

    /// <summary>上传文件类别 0:无 1:文章 2:帮助内容 3:店铺幻灯片 4:会员协议 5:积分礼品切换 6:积分礼品内容 7:可视化编辑模块 8:单页文章 9:广告 50:源码</summary>
    Int32 FileType { get; set; }

    /// <summary>文件类型 true为图片</summary>
    Boolean IsImg { get; set; }

    /// <summary>文件Url</summary>
    String? FileUrl { get; set; }

    /// <summary>文件信息ID</summary>
    Int32 ItemId { get; set; }

    /// <summary>创建者</summary>
    String? CreateUser { get; set; }

    /// <summary>创建者</summary>
    Int32 CreateUserID { get; set; }

    /// <summary>创建时间</summary>
    DateTime CreateTime { get; set; }

    /// <summary>创建地址</summary>
    String? CreateIP { get; set; }

    /// <summary>更新者</summary>
    String? UpdateUser { get; set; }

    /// <summary>更新者</summary>
    Int32 UpdateUserID { get; set; }

    /// <summary>更新时间</summary>
    DateTime UpdateTime { get; set; }

    /// <summary>更新地址</summary>
    String? UpdateIP { get; set; }
    #endregion
}
