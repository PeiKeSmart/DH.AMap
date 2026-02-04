using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Test.AMapWeb.Entity;

/// <summary>用户扩展表</summary>
public partial interface IUserEx
{
    #region 属性
    /// <summary>用户Id</summary>
    Int32 Id { get; set; }

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
