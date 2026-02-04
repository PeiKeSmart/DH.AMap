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

/// <summary>上传文件表</summary>
[Serializable]
[DataObject]
[Description("上传文件表")]
[BindIndex("IX_DH_Upload_ItemId_FileType", false, "ItemId,FileType")]
[BindTable("DH_Upload", Description = "上传文件表", ConnName = "DH", DbType = DatabaseType.None)]
public partial class UploadInfo : IUploadInfo, IEntity<IUploadInfo>
{
    #region 属性
    private Int32 _Id;
    /// <summary>编号</summary>
    [DisplayName("编号")]
    [Description("编号")]
    [DataObjectField(true, true, false, 0)]
    [BindColumn("Id", "编号", "")]
    public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

    private String? _OriginFileName;
    /// <summary>上传实际文件名</summary>
    [DisplayName("上传实际文件名")]
    [Description("上传实际文件名")]
    [DataObjectField(false, false, true, 200)]
    [BindColumn("OriginFileName", "上传实际文件名", "")]
    public String? OriginFileName { get => _OriginFileName; set { if (OnPropertyChanging("OriginFileName", value)) { _OriginFileName = value; OnPropertyChanged("OriginFileName"); } } }

    private String? _FileName;
    /// <summary>上传文件名</summary>
    [DisplayName("上传文件名")]
    [Description("上传文件名")]
    [DataObjectField(false, false, true, 50)]
    [BindColumn("FileName", "上传文件名", "")]
    public String? FileName { get => _FileName; set { if (OnPropertyChanging("FileName", value)) { _FileName = value; OnPropertyChanged("FileName"); } } }

    private Int64 _FileSize;
    /// <summary>上传文件大小</summary>
    [DisplayName("上传文件大小")]
    [Description("上传文件大小")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("FileSize", "上传文件大小", "")]
    public Int64 FileSize { get => _FileSize; set { if (OnPropertyChanging("FileSize", value)) { _FileSize = value; OnPropertyChanged("FileSize"); } } }

    private Int32 _FileType;
    /// <summary>上传文件类别 0:无 1:文章 2:帮助内容 3:店铺幻灯片 4:会员协议 5:积分礼品切换 6:积分礼品内容 7:可视化编辑模块 8:单页文章 9:广告 50:源码</summary>
    [DisplayName("上传文件类别0")]
    [Description("上传文件类别 0:无 1:文章 2:帮助内容 3:店铺幻灯片 4:会员协议 5:积分礼品切换 6:积分礼品内容 7:可视化编辑模块 8:单页文章 9:广告 50:源码")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("FileType", "上传文件类别 0:无 1:文章 2:帮助内容 3:店铺幻灯片 4:会员协议 5:积分礼品切换 6:积分礼品内容 7:可视化编辑模块 8:单页文章 9:广告 50:源码", "")]
    public Int32 FileType { get => _FileType; set { if (OnPropertyChanging("FileType", value)) { _FileType = value; OnPropertyChanged("FileType"); } } }

    private Boolean _IsImg;
    /// <summary>文件类型 true为图片</summary>
    [DisplayName("文件类型true为图片")]
    [Description("文件类型 true为图片")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("IsImg", "文件类型 true为图片", "")]
    public Boolean IsImg { get => _IsImg; set { if (OnPropertyChanging("IsImg", value)) { _IsImg = value; OnPropertyChanged("IsImg"); } } }

    private String? _FileUrl;
    /// <summary>文件Url</summary>
    [DisplayName("文件Url")]
    [Description("文件Url")]
    [DataObjectField(false, false, true, 100)]
    [BindColumn("FileUrl", "文件Url", "")]
    public String? FileUrl { get => _FileUrl; set { if (OnPropertyChanging("FileUrl", value)) { _FileUrl = value; OnPropertyChanged("FileUrl"); } } }

    private Int32 _ItemId;
    /// <summary>文件信息ID</summary>
    [DisplayName("文件信息ID")]
    [Description("文件信息ID")]
    [DataObjectField(false, false, false, 0)]
    [BindColumn("ItemId", "文件信息ID", "")]
    public Int32 ItemId { get => _ItemId; set { if (OnPropertyChanging("ItemId", value)) { _ItemId = value; OnPropertyChanged("ItemId"); } } }

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

    private DateTime _CreateTime;
    /// <summary>创建时间</summary>
    [DisplayName("创建时间")]
    [Description("创建时间")]
    [DataObjectField(false, false, true, 0)]
    [BindColumn("CreateTime", "创建时间", "")]
    public DateTime CreateTime { get => _CreateTime; set { if (OnPropertyChanging("CreateTime", value)) { _CreateTime = value; OnPropertyChanged("CreateTime"); } } }

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

    private DateTime _UpdateTime;
    /// <summary>更新时间</summary>
    [DisplayName("更新时间")]
    [Description("更新时间")]
    [DataObjectField(false, false, true, 0)]
    [BindColumn("UpdateTime", "更新时间", "")]
    public DateTime UpdateTime { get => _UpdateTime; set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } } }

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
    public void Copy(IUploadInfo model)
    {
        Id = model.Id;
        OriginFileName = model.OriginFileName;
        FileName = model.FileName;
        FileSize = model.FileSize;
        FileType = model.FileType;
        IsImg = model.IsImg;
        FileUrl = model.FileUrl;
        ItemId = model.ItemId;
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
            "OriginFileName" => _OriginFileName,
            "FileName" => _FileName,
            "FileSize" => _FileSize,
            "FileType" => _FileType,
            "IsImg" => _IsImg,
            "FileUrl" => _FileUrl,
            "ItemId" => _ItemId,
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
                case "OriginFileName": _OriginFileName = Convert.ToString(value); break;
                case "FileName": _FileName = Convert.ToString(value); break;
                case "FileSize": _FileSize = value.ToLong(); break;
                case "FileType": _FileType = value.ToInt(); break;
                case "IsImg": _IsImg = value.ToBoolean(); break;
                case "FileUrl": _FileUrl = Convert.ToString(value); break;
                case "ItemId": _ItemId = value.ToInt(); break;
                case "CreateUser": _CreateUser = Convert.ToString(value); break;
                case "CreateUserID": _CreateUserID = value.ToInt(); break;
                case "CreateTime": _CreateTime = value.ToDateTime(); break;
                case "CreateIP": _CreateIP = Convert.ToString(value); break;
                case "UpdateUser": _UpdateUser = Convert.ToString(value); break;
                case "UpdateUserID": _UpdateUserID = value.ToInt(); break;
                case "UpdateTime": _UpdateTime = value.ToDateTime(); break;
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
    public static UploadInfo? FindById(Int32 id)
    {
        if (id < 0) return null;

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Id == id);

        // 单对象缓存
        return Meta.SingleCache[id];

        //return Find(_.Id == id);
    }

    /// <summary>根据文件信息ID、上传文件类别0查找</summary>
    /// <param name="itemId">文件信息ID</param>
    /// <param name="fileType">上传文件类别0</param>
    /// <returns>实体列表</returns>
    public static IList<UploadInfo> FindAllByItemIdAndFileType(Int32 itemId, Int32 fileType)
    {
        if (itemId < 0) return [];
        if (fileType < 0) return [];

        // 实体缓存
        if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.ItemId == itemId && e.FileType == fileType);

        return FindAll(_.ItemId == itemId & _.FileType == fileType);
    }
    #endregion

    #region 高级查询
    /// <summary>高级查询</summary>
    /// <param name="fileType">上传文件类别 0:无 1:文章 2:帮助内容 3:店铺幻灯片 4:会员协议 5:积分礼品切换 6:积分礼品内容 7:可视化编辑模块 8:单页文章 9:广告 50:源码</param>
    /// <param name="itemId">文件信息ID</param>
    /// <param name="isImg">文件类型 true为图片</param>
    /// <param name="start">更新时间开始</param>
    /// <param name="end">更新时间结束</param>
    /// <param name="key">关键字</param>
    /// <param name="page">分页参数信息。可携带统计和数据权限扩展查询等信息</param>
    /// <returns>实体列表</returns>
    public static IList<UploadInfo> Search(Int32 fileType, Int32 itemId, Boolean? isImg, DateTime start, DateTime end, String key, PageParameter page)
    {
        var exp = new WhereExpression();

        if (fileType >= 0) exp &= _.FileType == fileType;
        if (itemId >= 0) exp &= _.ItemId == itemId;
        if (isImg != null) exp &= _.IsImg == isImg;
        exp &= _.UpdateTime.Between(start, end);
        if (!key.IsNullOrEmpty()) exp &= SearchWhereByKeys(key);

        return FindAll(exp, page);
    }
    #endregion

    #region 字段名
    /// <summary>取得上传文件表字段信息的快捷方式</summary>
    public partial class _
    {
        /// <summary>编号</summary>
        public static readonly Field Id = FindByName("Id");

        /// <summary>上传实际文件名</summary>
        public static readonly Field OriginFileName = FindByName("OriginFileName");

        /// <summary>上传文件名</summary>
        public static readonly Field FileName = FindByName("FileName");

        /// <summary>上传文件大小</summary>
        public static readonly Field FileSize = FindByName("FileSize");

        /// <summary>上传文件类别 0:无 1:文章 2:帮助内容 3:店铺幻灯片 4:会员协议 5:积分礼品切换 6:积分礼品内容 7:可视化编辑模块 8:单页文章 9:广告 50:源码</summary>
        public static readonly Field FileType = FindByName("FileType");

        /// <summary>文件类型 true为图片</summary>
        public static readonly Field IsImg = FindByName("IsImg");

        /// <summary>文件Url</summary>
        public static readonly Field FileUrl = FindByName("FileUrl");

        /// <summary>文件信息ID</summary>
        public static readonly Field ItemId = FindByName("ItemId");

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

    /// <summary>取得上传文件表字段名称的快捷方式</summary>
    public partial class __
    {
        /// <summary>编号</summary>
        public const String Id = "Id";

        /// <summary>上传实际文件名</summary>
        public const String OriginFileName = "OriginFileName";

        /// <summary>上传文件名</summary>
        public const String FileName = "FileName";

        /// <summary>上传文件大小</summary>
        public const String FileSize = "FileSize";

        /// <summary>上传文件类别 0:无 1:文章 2:帮助内容 3:店铺幻灯片 4:会员协议 5:积分礼品切换 6:积分礼品内容 7:可视化编辑模块 8:单页文章 9:广告 50:源码</summary>
        public const String FileType = "FileType";

        /// <summary>文件类型 true为图片</summary>
        public const String IsImg = "IsImg";

        /// <summary>文件Url</summary>
        public const String FileUrl = "FileUrl";

        /// <summary>文件信息ID</summary>
        public const String ItemId = "ItemId";

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
