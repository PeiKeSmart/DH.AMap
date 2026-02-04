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

/// <summary>单页文章翻译</summary>
[Serializable]
[DataObject]
[Description("单页文章翻译")]
[BindIndex("IU_DH_SingleArticleLan_SId_LId", true, "SId,LId")]
[BindTable("DH_SingleArticleLan", Description = "单页文章翻译", ConnName = "DH", DbType = DatabaseType.None)]
public partial class SingleArticleLan : ISingleArticleLan, IEntity<ISingleArticleLan>
{
    #region 属性
    private Int32 _Id;
    /// <summary>编号</summary>
    [DisplayName("编号")]
    [Description("编号")]
    [DataObjectField(true, true, false, 0)]
    [BindColumn("Id", "编号", "")]
    public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

    private Int32 _SId;
    /// <summary>单页文章Id</summary>
    [DisplayName("单页文章Id")]
    [Description("单页文章Id")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("SId", "单页文章Id", "")]
    public Int32 SId { get => _SId; set { if (OnPropertyChanging("SId", value)) { _SId = value; OnPropertyChanged("SId"); } } }

    private Int32 _LId;
    /// <summary>所属语言Id</summary>
    [DisplayName("所属语言Id")]
    [Description("所属语言Id")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("LId", "所属语言Id", "")]
    public Int32 LId { get => _LId; set { if (OnPropertyChanging("LId", value)) { _LId = value; OnPropertyChanged("LId"); } } }

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

    #region 获取/设置 字段值
    /// <summary>获取/设置 字段值</summary>
    /// <param name="name">字段名</param>
    /// <returns></returns>
    public override Object? this[String name]
    {
        get => name switch
        {
            "Id" => _Id,
            "SId" => _SId,
            "LId" => _LId,
            "Name" => _Name,
            "Content" => _Content,
            "MobileContent" => _MobileContent,
            "Summary" => _Summary,
            "Pic" => _Pic,
            "SeoTitle" => _SeoTitle,
            "Keys" => _Keys,
            "Description" => _Description,
            _ => base[name]
        };
        set
        {
            switch (name)
            {
                case "Id": _Id = value.ToInt(); break;
                case "SId": _SId = value.ToInt(); break;
                case "LId": _LId = value.ToInt(); break;
                case "Name": _Name = Convert.ToString(value); break;
                case "Content": _Content = Convert.ToString(value); break;
                case "MobileContent": _MobileContent = Convert.ToString(value); break;
                case "Summary": _Summary = Convert.ToString(value); break;
                case "Pic": _Pic = Convert.ToString(value); break;
                case "SeoTitle": _SeoTitle = Convert.ToString(value); break;
                case "Keys": _Keys = Convert.ToString(value); break;
                case "Description": _Description = Convert.ToString(value); break;
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
    public static SingleArticleLan? FindById(Int32 id)
    {
        if (id < 0) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Id == id);

        // 单对象缓存
        return Meta.SingleCache[id];

        //return Find(_.Id == id);
    }

    /// <summary>根据单页文章Id、所属语言Id查找</summary>
    /// <param name="sId">单页文章Id</param>
    /// <param name="lId">所属语言Id</param>
    /// <returns>实体对象</returns>
    public static SingleArticleLan? FindBySIdAndLId(Int32 sId, Int32 lId)
    {
        if (sId < 0) return null;
        if (lId < 0) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.SId == sId && e.LId == lId);

        return Find(_.SId == sId & _.LId == lId);
    }

    /// <summary>根据单页文章Id查找</summary>
    /// <param name="sId">单页文章Id</param>
    /// <returns>实体列表</returns>
    public static IList<SingleArticleLan> FindAllBySId(Int32 sId)
    {
        if (sId < 0) return [];

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SId == sId);

        return FindAll(_.SId == sId);
    }
    #endregion

    #region 字段名
    /// <summary>取得单页文章翻译字段信息的快捷方式</summary>
    public partial class _
    {
        /// <summary>编号</summary>
        public static readonly Field Id = FindByName("Id");

        /// <summary>单页文章Id</summary>
        public static readonly Field SId = FindByName("SId");

        /// <summary>所属语言Id</summary>
        public static readonly Field LId = FindByName("LId");

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

        /// <summary>SEO标题</summary>
        public static readonly Field SeoTitle = FindByName("SeoTitle");

        /// <summary>SEO关键词</summary>
        public static readonly Field Keys = FindByName("Keys");

        /// <summary>SEO描述</summary>
        public static readonly Field Description = FindByName("Description");

        static Field FindByName(String name) => Meta.Table.FindByName(name);
    }

    /// <summary>取得单页文章翻译字段名称的快捷方式</summary>
    public partial class __
    {
        /// <summary>编号</summary>
        public const String Id = "Id";

        /// <summary>单页文章Id</summary>
        public const String SId = "SId";

        /// <summary>所属语言Id</summary>
        public const String LId = "LId";

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

        /// <summary>SEO标题</summary>
        public const String SeoTitle = "SeoTitle";

        /// <summary>SEO关键词</summary>
        public const String Keys = "Keys";

        /// <summary>SEO描述</summary>
        public const String Description = "Description";
    }
    #endregion
}
