using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Test.AMapWeb.Entity;

/// <summary>单页文章</summary>
public partial class SingleArticleModel
{
    #region 属性
    /// <summary>编号</summary>
    public Int32 Id { get; set; }

    /// <summary>文章跳转链接</summary>
    public String? Url { get; set; }

    /// <summary>文章是否显示。默认为是</summary>
    public Boolean Show { get; set; }

    /// <summary>文章排序</summary>
    public Int32 Sort { get; set; }

    /// <summary>调用别名。不可重复</summary>
    public String Code { get; set; } = null!;

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

    /// <summary>是否允许删除。默认为是</summary>
    public Boolean AllowDel { get; set; }

    /// <summary>模板名称</summary>
    public String? ViewName { get; set; }

    /// <summary>SEO标题</summary>
    public String? SeoTitle { get; set; }

    /// <summary>SEO关键词</summary>
    public String? Keys { get; set; }

    /// <summary>SEO描述</summary>
    public String? Description { get; set; }

    /// <summary>查看次数</summary>
    public Int32 Hits { get; set; }

    /// <summary>创建者</summary>
    public String? CreateUser { get; set; }

    /// <summary>创建者</summary>
    public Int32 CreateUserID { get; set; }

    /// <summary>创建时间</summary>
    public Int64 CreateTime { get; set; }

    /// <summary>创建地址</summary>
    public String? CreateIP { get; set; }

    /// <summary>更新者</summary>
    public String? UpdateUser { get; set; }

    /// <summary>更新者</summary>
    public Int32 UpdateUserID { get; set; }

    /// <summary>更新时间</summary>
    public Int64 UpdateTime { get; set; }

    /// <summary>更新地址</summary>
    public String? UpdateIP { get; set; }
    #endregion

    #region 拷贝
    /// <summary>拷贝模型对象</summary>
    /// <param name="model">模型</param>
    public void Copy(ISingleArticle model)
    {
        Id = model.Id;
        Url = model.Url;
        Show = model.Show;
        Sort = model.Sort;
        Code = model.Code;
        Name = model.Name;
        Content = model.Content;
        MobileContent = model.MobileContent;
        Summary = model.Summary;
        Pic = model.Pic;
        AllowDel = model.AllowDel;
        ViewName = model.ViewName;
        SeoTitle = model.SeoTitle;
        Keys = model.Keys;
        Description = model.Description;
        Hits = model.Hits;
        CreateUser = model.CreateUser;
        CreateUserID = model.CreateUserID;
        CreateTime = model.CreateTime;
        CreateIP = model.CreateIP;
        UpdateUser = model.UpdateUser;
        UpdateUserID = model.UpdateUserID;
        UpdateTime = model.UpdateTime;
        UpdateIP = model.UpdateIP;
    }
    #endregion
}
