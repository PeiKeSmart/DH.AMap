using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using NewLife;
using NewLife.Data;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Test.AMapWeb.Entity;

/// <summary>单页文章</summary>
[Serializable]
[DataObject]
[Description("单页文章")]
[BindIndex("IU_DH_SingleArticle_Code", true, "Code")]
[BindIndex("IU_DH_SingleArticle_Name", true, "Name")]
[BindTable("DH_SingleArticle", Description = "单页文章", ConnName = "DH", DbType = DatabaseType.None)]
public partial class SingleArticle : ISingleArticle, IEntity<ISingleArticle>
{
    #region 属性
    private Int32 _Id;
    /// <summary>编号</summary>
    [DisplayName("编号")]
    [Description("编号")]
    [DataObjectField(true, true, false, 0)]
    [BindColumn("Id", "编号", "")]
    public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

    private String? _Url;
    /// <summary>文章跳转链接</summary>
    [DisplayName("文章跳转链接")]
    [Description("文章跳转链接")]
    [DataObjectField(false, false, true, 200)]
    [BindColumn("Url", "文章跳转链接", "")]
    public String? Url { get => _Url; set { if (OnPropertyChanging("Url", value)) { _Url = value; OnPropertyChanged("Url"); } } }

    private Boolean _Show;
    /// <summary>文章是否显示。默认为是</summary>
    [DisplayName("文章是否显示")]
    [Description("文章是否显示。默认为是")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("Show", "文章是否显示。默认为是", "")]
    public Boolean Show { get => _Show; set { if (OnPropertyChanging("Show", value)) { _Show = value; OnPropertyChanged("Show"); } } }

    private Int32 _Sort;
    /// <summary>文章排序</summary>
    [DisplayName("文章排序")]
    [Description("文章排序")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("Sort", "文章排序", "", DefaultValue = "255")]
    public Int32 Sort { get => _Sort; set { if (OnPropertyChanging("Sort", value)) { _Sort = value; OnPropertyChanged("Sort"); } } }

    private String _Code = null!;
    /// <summary>调用别名。不可重复</summary>
    [DisplayName("调用别名")]
    [Description("调用别名。不可重复")]
    [DataObjectField(false, false, false, 50)]
    [BindColumn("Code", "调用别名。不可重复", "")]
    public String Code { get => _Code; set { if (OnPropertyChanging("Code", value)) { _Code = value; OnPropertyChanged("Code"); } } }

    private String? _Name;
    /// <summary>文章标题</summary>
    [DisplayName("文章标题")]
    [Description("文章标题")]
    [DataObjectField(false, false, true, 200)]
    [BindColumn("Name", "文章标题", "", Master = true)]
    public String? Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

    private String? _Content;
    /// <summary>内容</summary>
    [DisplayName("内容")]
    [Description("内容")]
    [DataObjectField(false, false, true, 0)]
    [BindColumn("Content", "内容", "text")]
    public String? Content { get => _Content; set { if (OnPropertyChanging("Content", value)) { _Content = value; OnPropertyChanged("Content"); } } }

    private String? _MobileContent;
    /// <summary>内容(移动端)</summary>
    [DisplayName("内容(移动端)")]
    [Description("内容(移动端)")]
    [DataObjectField(false, false, true, 0)]
    [BindColumn("MobileContent", "内容(移动端)", "text")]
    public String? MobileContent { get => _MobileContent; set { if (OnPropertyChanging("MobileContent", value)) { _MobileContent = value; OnPropertyChanged("MobileContent"); } } }

    private String? _Summary;
    /// <summary>简介</summary>
    [DisplayName("简介")]
    [Description("简介")]
    [DataObjectField(false, false, true, 512)]
    [BindColumn("Summary", "简介", "")]
    public String? Summary { get => _Summary; set { if (OnPropertyChanging("Summary", value)) { _Summary = value; OnPropertyChanged("Summary"); } } }

    private String? _Pic;
    /// <summary>文章主图</summary>
    [DisplayName("文章主图")]
    [Description("文章主图")]
    [DataObjectField(false, false, true, 255)]
    [BindColumn("Pic", "文章主图", "")]
    public String? Pic { get => _Pic; set { if (OnPropertyChanging("Pic", value)) { _Pic = value; OnPropertyChanged("Pic"); } } }

    private Boolean _AllowDel;
    /// <summary>是否允许删除。默认为是</summary>
    [DisplayName("是否允许删除")]
    [Description("是否允许删除。默认为是")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("AllowDel", "是否允许删除。默认为是", "", DefaultValue = "True")]
    public Boolean AllowDel { get => _AllowDel; set { if (OnPropertyChanging("AllowDel", value)) { _AllowDel = value; OnPropertyChanged("AllowDel"); } } }

    private String? _ViewName;
    /// <summary>模板名称</summary>
    [DisplayName("模板名称")]
    [Description("模板名称")]
    [DataObjectField(false, false, true, 100)]
    [BindColumn("ViewName", "模板名称", "")]
    public String? ViewName { get => _ViewName; set { if (OnPropertyChanging("ViewName", value)) { _ViewName = value; OnPropertyChanged("ViewName"); } } }

    private String? _SeoTitle;
    /// <summary>SEO标题</summary>
    [DisplayName("SEO标题")]
    [Description("SEO标题")]
    [DataObjectField(false, false, true, 255)]
    [BindColumn("SeoTitle", "SEO标题", "")]
    public String? SeoTitle { get => _SeoTitle; set { if (OnPropertyChanging("SeoTitle", value)) { _SeoTitle = value; OnPropertyChanged("SeoTitle"); } } }

    private String? _Keys;
    /// <summary>SEO关键词</summary>
    [DisplayName("SEO关键词")]
    [Description("SEO关键词")]
    [DataObjectField(false, false, true, 255)]
    [BindColumn("Keys", "SEO关键词", "")]
    public String? Keys { get => _Keys; set { if (OnPropertyChanging("Keys", value)) { _Keys = value; OnPropertyChanged("Keys"); } } }

    private String? _Description;
    /// <summary>SEO描述</summary>
    [DisplayName("SEO描述")]
    [Description("SEO描述")]
    [DataObjectField(false, false, true, 255)]
    [BindColumn("Description", "SEO描述", "")]
    public String? Description { get => _Description; set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } } }

    private Int32 _Hits;
    /// <summary>查看次数</summary>
    [DisplayName("查看次数")]
    [Description("查看次数")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("Hits", "查看次数", "")]
    public Int32 Hits { get => _Hits; set { if (OnPropertyChanging("Hits", value)) { _Hits = value; OnPropertyChanged("Hits"); } } }

    private String? _CreateUser;
    /// <summary>创建者</summary>
    [DisplayName("创建者")]
    [Description("创建者")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("CreateUser", "创建者", "")]
    public String? CreateUser { get => _CreateUser; set { if (OnPropertyChanging("CreateUser", value)) { _CreateUser = value; OnPropertyChanged("CreateUser"); } } }

    private Int32 _CreateUserID;
    /// <summary>创建者</summary>
    [DisplayName("创建者")]
    [Description("创建者")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("CreateUserID", "创建者", "")]
    public Int32 CreateUserID { get => _CreateUserID; set { if (OnPropertyChanging("CreateUserID", value)) { _CreateUserID = value; OnPropertyChanged("CreateUserID"); } } }

    private Int64 _CreateTime;
    /// <summary>创建时间</summary>
    [DisplayName("创建时间")]
    [Description("创建时间")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("CreateTime", "创建时间", "")]
    public Int64 CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

    private String? _CreateIP;
    /// <summary>创建地址</summary>
    [DisplayName("创建地址")]
    [Description("创建地址")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("CreateIP", "创建地址", "")]
    public String? CreateIP { get => _CreateIP; set { if (OnPropertyChanging("CreateIP", value)) { _CreateIP = value; OnPropertyChanged("CreateIP"); } } }

    private String? _UpdateUser;
    /// <summary>更新者</summary>
    [DisplayName("更新者")]
    [Description("更新者")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("UpdateUser", "更新者", "")]
    public String? UpdateUser { get => _UpdateUser; set { if (OnPropertyChanging("UpdateUser", value)) { _UpdateUser = value; OnPropertyChanged("UpdateUser"); } } }

    private Int32 _UpdateUserID;
    /// <summary>更新者</summary>
    [DisplayName("更新者")]
    [Description("更新者")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("UpdateUserID", "更新者", "")]
    public Int32 UpdateUserID { get => _UpdateUserID; set { if (OnPropertyChanging("UpdateUserID", value)) { _UpdateUserID = value; OnPropertyChanged("UpdateUserID"); } } }

    private Int64 _UpdateTime;
    /// <summary>更新时间</summary>
    [DisplayName("更新时间")]
    [Description("更新时间")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("UpdateTime", "更新时间", "")]
    public Int64 UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

    private String? _UpdateIP;
    /// <summary>更新地址</summary>
    [DisplayName("更新地址")]
    [Description("更新地址")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("UpdateIP", "更新地址", "")]
    public String? UpdateIP { get => _UpdateIP; set { if (OnPropertyChanging("UpdateIP", value)) { _UpdateIP = value; OnPropertyChanged("UpdateIP"); } } }
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

    #region 获取/设置 字段值
    /// <summary>获取/设置 字段值</summary>
    /// <param name="name">字段名</param>
    /// <returns></returns>
    public override Object? this[String name]
    {
        get => name switch
        {
            "Id" => _Id,
            "Url" => _Url,
            "Show" => _Show,
            "Sort" => _Sort,
            "Code" => _Code,
            "Name" => _Name,
            "Content" => _Content,
            "MobileContent" => _MobileContent,
            "Summary" => _Summary,
            "Pic" => _Pic,
            "AllowDel" => _AllowDel,
            "ViewName" => _ViewName,
            "SeoTitle" => _SeoTitle,
            "Keys" => _Keys,
            "Description" => _Description,
            "Hits" => _Hits,
            "CreateUser" => _CreateUser,
            "CreateUserID" => _CreateUserID,
            "CreateTime" => _CreateTime,
            "CreateIP" => _CreateIP,
            "UpdateUser" => _UpdateUser,
            "UpdateUserID" => _UpdateUserID,
            "UpdateTime" => _UpdateTime,
            "UpdateIP" => _UpdateIP,
            _ => base[name]
        };
        set
        {
            switch (name)
            {
                case "Id": _Id = value.ToInt(); break;
                case "Url": _Url = Convert.ToString(value); break;
                case "Show": _Show = value.ToBoolean(); break;
                case "Sort": _Sort = value.ToInt(); break;
                case "Code": _Code = Convert.ToString(value); break;
                case "Name": _Name = Convert.ToString(value); break;
                case "Content": _Content = Convert.ToString(value); break;
                case "MobileContent": _MobileContent = Convert.ToString(value); break;
                case "Summary": _Summary = Convert.ToString(value); break;
                case "Pic": _Pic = Convert.ToString(value); break;
                case "AllowDel": _AllowDel = value.ToBoolean(); break;
                case "ViewName": _ViewName = Convert.ToString(value); break;
                case "SeoTitle": _SeoTitle = Convert.ToString(value); break;
                case "Keys": _Keys = Convert.ToString(value); break;
                case "Description": _Description = Convert.ToString(value); break;
                case "Hits": _Hits = value.ToInt(); break;
                case "CreateUser": _CreateUser = Convert.ToString(value); break;
                case "CreateUserID": _CreateUserID = value.ToInt(); break;
                case "CreateTime": _CreateTime = value.ToLong(); break;
                case "CreateIP": _CreateIP = Convert.ToString(value); break;
                case "UpdateUser": _UpdateUser = Convert.ToString(value); break;
                case "UpdateUserID": _UpdateUserID = value.ToInt(); break;
                case "UpdateTime": _UpdateTime = value.ToLong(); break;
                case "UpdateIP": _UpdateIP = Convert.ToString(value); break;
                default: base[name] = value; break;
            }
        }
    }
    #endregion

    #region 关联映射
    #endregion

    #region 扩展查询
    /// <summary>根据编号查找</summary>
    /// <param name="id">编号</param>
    /// <returns>实体对象</returns>
    public static SingleArticle? FindById(Int32 id)
    {
        if (id < 0) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Id == id);

        // 单对象缓存
        return Meta.SingleCache[id];

        //return Find(_.Id == id);
    }

    /// <summary>根据调用别名查找</summary>
    /// <param name="code">调用别名</param>
    /// <returns>实体对象</returns>
    public static SingleArticle? FindByCode(String code)
    {
        if (code.IsNullOrEmpty()) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Code.EqualIgnoreCase(code));

        return Find(_.Code == code);
    }

    /// <summary>根据文章标题查找</summary>
    /// <param name="name">文章标题</param>
    /// <returns>实体对象</returns>
    public static SingleArticle? FindByName(String? name)
    {
        if (name == null) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Name.EqualIgnoreCase(name));

        // 单对象缓存
        return Meta.SingleCache.GetItemWithSlaveKey(name) as SingleArticle;

        //return Find(_.Name == name);
    }
    #endregion

    #region 高级查询
    /// <summary>高级查询</summary>
    /// <param name="code">调用别名。不可重复</param>
    /// <param name="show">文章是否显示。默认为是</param>
    /// <param name="allowDel">是否允许删除。默认为是</param>
    /// <param name="start">更新时间开始</param>
    /// <param name="end">更新时间结束</param>
    /// <param name="key">关键字</param>
    /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
    /// <returns>实体列表</returns>
    public static IList<SingleArticle> Search(String code, Boolean? show, Boolean? allowDel, DateTime start, DateTime end, String key, PageParameter page)
    {
        var exp = new WhereExpression();

        if (!code.IsNullOrEmpty()) exp &= _.Code == code;
        if (show != null) exp &= _.Show == show;
        if (allowDel != null) exp &= _.AllowDel == allowDel;
        exp &= _.UpdateTime.Between(start, end, Meta.Factory.Snow);
        if (!key.IsNullOrEmpty()) exp &= SearchWhereByKeys(key);

        return FindAll(exp, page);
    }
    #endregion

    #region 字段名
    /// <summary>取得单页文章字段信息的快捷方式</summary>
    public partial class _
    {
        /// <summary>编号</summary>
        public static readonly Field Id = FindByName("Id");

        /// <summary>文章跳转链接</summary>
        public static readonly Field Url = FindByName("Url");

        /// <summary>文章是否显示。默认为是</summary>
        public static readonly Field Show = FindByName("Show");

        /// <summary>文章排序</summary>
        public static readonly Field Sort = FindByName("Sort");

        /// <summary>调用别名。不可重复</summary>
        public static readonly Field Code = FindByName("Code");

        /// <summary>文章标题</summary>
        public static readonly Field Name = FindByName("Name");

        /// <summary>内容</summary>
        public static readonly Field Content = FindByName("Content");

        /// <summary>内容(移动端)</summary>
        public static readonly Field MobileContent = FindByName("MobileContent");

        /// <summary>简介</summary>
        public static readonly Field Summary = FindByName("Summary");

        /// <summary>文章主图</summary>
        public static readonly Field Pic = FindByName("Pic");

        /// <summary>是否允许删除。默认为是</summary>
        public static readonly Field AllowDel = FindByName("AllowDel");

        /// <summary>模板名称</summary>
        public static readonly Field ViewName = FindByName("ViewName");

        /// <summary>SEO标题</summary>
        public static readonly Field SeoTitle = FindByName("SeoTitle");

        /// <summary>SEO关键词</summary>
        public static readonly Field Keys = FindByName("Keys");

        /// <summary>SEO描述</summary>
        public static readonly Field Description = FindByName("Description");

        /// <summary>查看次数</summary>
        public static readonly Field Hits = FindByName("Hits");

        /// <summary>创建者</summary>
        public static readonly Field CreateUser = FindByName("CreateUser");

        /// <summary>创建者</summary>
        public static readonly Field CreateUserID = FindByName("CreateUserID");

        /// <summary>创建时间</summary>
        public static readonly Field CreateTime = FindByName("CreateTime");

        /// <summary>创建地址</summary>
        public static readonly Field CreateIP = FindByName("CreateIP");

        /// <summary>更新者</summary>
        public static readonly Field UpdateUser = FindByName("UpdateUser");

        /// <summary>更新者</summary>
        public static readonly Field UpdateUserID = FindByName("UpdateUserID");

        /// <summary>更新时间</summary>
        public static readonly Field UpdateTime = FindByName("UpdateTime");

        /// <summary>更新地址</summary>
        public static readonly Field UpdateIP = FindByName("UpdateIP");

        static Field FindByName(String name) => Meta.Table.FindByName(name);
    }

    /// <summary>取得单页文章字段名称的快捷方式</summary>
    public partial class __
    {
        /// <summary>编号</summary>
        public const String Id = "Id";

        /// <summary>文章跳转链接</summary>
        public const String Url = "Url";

        /// <summary>文章是否显示。默认为是</summary>
        public const String Show = "Show";

        /// <summary>文章排序</summary>
        public const String Sort = "Sort";

        /// <summary>调用别名。不可重复</summary>
        public const String Code = "Code";

        /// <summary>文章标题</summary>
        public const String Name = "Name";

        /// <summary>内容</summary>
        public const String Content = "Content";

        /// <summary>内容(移动端)</summary>
        public const String MobileContent = "MobileContent";

        /// <summary>简介</summary>
        public const String Summary = "Summary";

        /// <summary>文章主图</summary>
        public const String Pic = "Pic";

        /// <summary>是否允许删除。默认为是</summary>
        public const String AllowDel = "AllowDel";

        /// <summary>模板名称</summary>
        public const String ViewName = "ViewName";

        /// <summary>SEO标题</summary>
        public const String SeoTitle = "SeoTitle";

        /// <summary>SEO关键词</summary>
        public const String Keys = "Keys";

        /// <summary>SEO描述</summary>
        public const String Description = "Description";

        /// <summary>查看次数</summary>
        public const String Hits = "Hits";

        /// <summary>创建者</summary>
        public const String CreateUser = "CreateUser";

        /// <summary>创建者</summary>
        public const String CreateUserID = "CreateUserID";

        /// <summary>创建时间</summary>
        public const String CreateTime = "CreateTime";

        /// <summary>创建地址</summary>
        public const String CreateIP = "CreateIP";

        /// <summary>更新者</summary>
        public const String UpdateUser = "UpdateUser";

        /// <summary>更新者</summary>
        public const String UpdateUserID = "UpdateUserID";

        /// <summary>更新时间</summary>
        public const String UpdateTime = "UpdateTime";

        /// <summary>更新地址</summary>
        public const String UpdateIP = "UpdateIP";
    }
    #endregion
}
