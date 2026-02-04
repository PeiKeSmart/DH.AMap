using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Test.AMapWeb.Entity;

/// <summary>单页文章</summary>
public partial interface ISingleArticle
{
    #region 属性
    /// <summary>编号</summary>
    Int32 Id { get; set; }

    /// <summary>文章跳转链接</summary>
    String? Url { get; set; }

    /// <summary>文章是否显示。默认为是</summary>
    Boolean Show { get; set; }

    /// <summary>文章排序</summary>
    Int32 Sort { get; set; }

    /// <summary>调用别名。不可重复</summary>
    String Code { get; set; }

    /// <summary>文章标题</summary>
    String? Name { get; set; }

    /// <summary>内容</summary>
    String? Content { get; set; }

    /// <summary>内容(移动端)</summary>
    String? MobileContent { get; set; }

    /// <summary>简介</summary>
    String? Summary { get; set; }

    /// <summary>文章主图</summary>
    String? Pic { get; set; }

    /// <summary>是否允许删除。默认为是</summary>
    Boolean AllowDel { get; set; }

    /// <summary>模板名称</summary>
    String? ViewName { get; set; }

    /// <summary>SEO标题</summary>
    String? SeoTitle { get; set; }

    /// <summary>SEO关键词</summary>
    String? Keys { get; set; }

    /// <summary>SEO描述</summary>
    String? Description { get; set; }

    /// <summary>查看次数</summary>
    Int32 Hits { get; set; }

    /// <summary>创建者</summary>
    String? CreateUser { get; set; }

    /// <summary>创建者</summary>
    Int32 CreateUserID { get; set; }

    /// <summary>创建时间</summary>
    Int64 CreateTime { get; set; }

    /// <summary>创建地址</summary>
    String? CreateIP { get; set; }

    /// <summary>更新者</summary>
    String? UpdateUser { get; set; }

    /// <summary>更新者</summary>
    Int32 UpdateUserID { get; set; }

    /// <summary>更新时间</summary>
    Int64 UpdateTime { get; set; }

    /// <summary>更新地址</summary>
    String? UpdateIP { get; set; }
    #endregion
}
