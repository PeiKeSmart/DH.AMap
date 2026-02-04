using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Test.AMapWeb.Entity;

/// <summary>单页文章翻译</summary>
public partial class SingleArticleLanModel
{
    #region 属性
    /// <summary>编号</summary>
    public Int32 Id { get; set; }

    /// <summary>单页文章Id</summary>
    public Int32 SId { get; set; }

    /// <summary>所属语言Id</summary>
    public Int32 LId { get; set; }

    /// <summary>文章标题</summary>
    public String? Name { get; set; }

    /// <summary>内容</summary>
    public String? Content { get; set; }

    /// <summary>内容(移动端)</summary>
    public String? MobileContent { get; set; }

    /// <summary>简介</summary>
    public String? Summary { get; set; }

    /// <summary>文章主图</summary>
    public String? Pic { get; set; }

    /// <summary>SEO标题</summary>
    public String? SeoTitle { get; set; }

    /// <summary>SEO关键词</summary>
    public String? Keys { get; set; }

    /// <summary>SEO描述</summary>
    public String? Description { get; set; }
    #endregion

    #region 拷贝
    /// <summary>拷贝模型对象</summary>
    /// <param name="model">模型</param>
    public void Copy(ISingleArticleLan model)
    {
        Id = model.Id;
        SId = model.SId;
        LId = model.LId;
        Name = model.Name;
        Content = model.Content;
        MobileContent = model.MobileContent;
        Summary = model.Summary;
        Pic = model.Pic;
        SeoTitle = model.SeoTitle;
        Keys = model.Keys;
        Description = model.Description;
    }
    #endregion
}
