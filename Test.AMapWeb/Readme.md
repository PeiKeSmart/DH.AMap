# Test.AMapWeb - 高德地图代理测试项目

## 项目简介

本项目是 DH.AMap 高德地图反向代理功能的测试项目，用于验证代理方案在实际前后端交互中的使用情况。

## 项目结构

```
Test.AMapWeb/
├── Controllers/           # 控制器目录
│   └── HomeController.cs # 主控制器
├── Views/                 # 视图目录
│   ├── Shared/           # 共享视图
│   │   └── _Root.cshtml  # 主布局页面
│   ├── Home/             # Home控制器视图
│   │   ├── Index.cshtml           # 首页
│   │   ├── ApiTest.cshtml         # JavaScript API测试
│   │   ├── GeoCode.cshtml         # 地理编码测试
│   │   └── ReverseGeoCode.cshtml  # 逆地理编码测试
│   └── _ViewStart.cshtml # 视图启动文件
├── Properties/            # 项目属性
│   └── launchSettings.json # 启动配置
├── appsettings.json      # 应用配置
├── Program.cs            # 程序入口
└── Test.AMapWeb.csproj   # 项目文件
```

## 功能说明

### 1. JavaScript API 测试 (/Home/ApiTest)

测试高德地图 JavaScript API 2.0 的基础功能：
- 通过代理端点加载地图 API
- 创建地图实例并显示
- 添加/清除标记点
- 地图交互功能（缩放、拖拽、点击等）

**使用的代理接口**：
- `/_AMapService/maps?v=2.0` - 加载 JavaScript API

### 2. 地理编码测试 (/Home/GeoCode)

测试将地址转换为经纬度坐标：
- 输入地址和城市信息
- 调用地理编码 API
- 在地图上标注查询结果
- 显示详细的坐标信息

**使用的代理接口**：
- `/_AMapService/v3/geocode/geo` - 地理编码

**示例请求**：
```javascript
fetch('/_AMapService/v3/geocode/geo?address=北京市朝阳区阜通东大街6号&city=北京')
```

### 3. 逆地理编码测试 (/Home/ReverseGeoCode)

测试将经纬度坐标转换为地址信息：
- 输入经纬度坐标
- 点击地图获取坐标
- 调用逆地理编码 API
- 显示地址、道路、POI等详细信息

**使用的代理接口**：
- `/_AMapService/v3/geocode/regeo` - 逆地理编码

**示例请求**：
```javascript
fetch('/_AMapService/v3/geocode/regeo?location=116.481488,39.990464&extensions=all')
```

## 使用方法

### 1. 配置高德地图密钥

首次运行时，系统会自动在项目根目录的 `Config` 文件夹下创建 `AMapSetting.config` 文件。

编辑 `Config/AMapSetting.config`：

```xml
<?xml version="1.0" encoding="utf-8"?>
<AMapSetting>
  <!-- 必填：高德地图 Key -->
  <AMapKey>your-amap-key-here</AMapKey>
  
  <!-- 必填：Web 服务 API 私钥（用于数字签名） -->
  <AMapSecret>your-amap-secret-here</AMapSecret>
  
  <!-- 可选：是否启用数字签名验证，默认 true -->
  <EnableSignature>true</EnableSignature>
</AMapSetting>
```

**如何获取 Key 和 Secret？**
1. 登录 [高德开放平台控制台](https://console.amap.com/)
2. 创建应用，选择 "Web 服务" 类型
3. 应用管理中查看 **Key** 和 **私钥（Secret）**

### 2. 运行项目

```bash
# 进入项目目录
cd Test.AMapWeb

# 运行项目
dotnet run

# 或者使用热重载
dotnet watch run
```

### 3. 访问测试页面

- 首页：http://localhost:5000/
- JavaScript API测试：http://localhost:5000/Home/ApiTest
- 地理编码测试：http://localhost:5000/Home/GeoCode
- 逆地理编码测试：http://localhost:5000/Home/ReverseGeoCode

## 代理方案验证要点

### 前端使用方式

1. **JavaScript API 加载**
   ```html
   <!-- 通过代理端点加载，无需暴露密钥 -->
   <script src="/_AMapService/maps?v=2.0"></script>
   ```

2. **REST API 调用**
   ```javascript
   // 地理编码
   fetch('/_AMapService/v3/geocode/geo?address=北京市朝阳区')
   
   // 逆地理编码
   fetch('/_AMapService/v3/geocode/regeo?location=116.481488,39.990464')
   ```

### 后端代理逻辑

代理逻辑位于 `DH.AMap\DHStartup.cs` 中的 `UseDHEndpoints` 方法：

1. **拦截请求**：匹配 `/_AMapService/**` 路径
2. **添加 Key**：自动附加配置的高德地图 Key
3. **计算签名**：如果启用了数字签名，使用 Secret 计算 sig 参数
   - 签名算法：`MD5(请求路径 + Secret)`
4. **转发请求**：将请求转发到高德地图官方接口
5. **返回结果**：将响应返回给前端

### 安全性验证 Key 和 Secret
- ✅ 浏览器开发者工具网络请求中看不到真实 Key 和 Secret
- ✅ 所有请求通过后端代理，Key 和签名在服务器端添加
- ✅ 数字签名验证防止 API 被盗用
- ✅ 浏览器开发者工具网络请求中看不到真实密钥
- ✅ 所有请求通过后端代理，密钥在服务器端添加
- ✅ 可以统一管理和更换密钥，无需修改前端代码

## 技术栈

- ASP.NET Core 8.0（标准 MVC）
- DH.AMap 地图SDK
- 高德地图 JavaScript API 2.0
- Fetch API

**注意**：测试项目使用标准 ASP.NET Core MVC，不依赖 Pek 框架的其他组件，方便快速运行和测试。

## 测试建议

1. **JavaScript API 测试**
   - 检查地图是否正常加载
   - 测试标记添加/删除功能
   - 验证地图交互操作（缩放、拖拽）
   - 查看浏览器控制台日志

2. **地理编码测试**
   - 测试不同格式的地址输入
   - 验证城市参数的影响
   - 检查多个结果的显示
   - 观察地图标注效果

3. **逆地理编码测试**
   - 测试不同的坐标输入
   - 点击地图测试自动查询
   - 验证详细信息显示（base vs all）
   - 检查附近POI和道路信息

## 常见问题

### 1. 地图无法加载
 Key 和 Secret 是否配置正确
- 确认在高德控制台创建的应用类型是否为 "Web 服务"
- 确认 Key 对应的服务是否已开通（Web服务、JavaScript API）
- 如果启用了数字签名，确认 Secret 配置正确
- 确认密钥对应的服务是否已开通（Web服务、JavaScript API）
- 查看浏览器控制台是否有错误信息

### 2. API 调用失败

- 检查代理端点是否正确配置
- 确认 DHStartup.cs 中的路由注册是否生效
- 查看服务器端日志排查问题

### 3. CORS 跨域问题

- 代理方案已解决跨域问题
- 所有请求都是同源请求（通过后端代理）

## 参考资料

- [DH.AMap 使用示例](../Doc/使用示例.md)
- [高德地图 JavaScript API 文档](https://lbs.amap.com/api/javascript-api-v2/summary)
- [高德地图 Web服务 API 文档](https://lbs.amap.com/api/webservice/summary)

## 许可证

MIT License

Copyright (c) 2020-2025 湖北登灏科技有限公司
