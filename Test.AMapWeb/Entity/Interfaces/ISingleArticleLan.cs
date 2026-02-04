using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Test.AMapWeb.Entity;

/// <summary>单页文章翻译</summary>
public partial interface ISingleArticleLan
{
    #region 属性
    /// <summary>编号</summary>
    Int32 Id { get; set; }

    /// <summary>单页文章Id</summary>
    Int32 SId { get; set; }

    /// <summary>所属语言Id</summary>
    Int32 LId { get; set; }

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

    /// <summary>SEO标题</summary>
    String? SeoTitle { get; set; }

    /// <summary>SEO关键词</summary>
    String? Keys { get; set; }

    /// <summary>SEO描述</summary>
    String? Description { get; set; }
    #endregion
}
