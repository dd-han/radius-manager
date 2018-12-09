# Radius Manager

這是一個由 ASP.net Core 撰寫的 Freeradius 管理前端。

## 開發環境設定

```bash
dotnet restore
dotnet tool install dotnet-aspnet-codegenerator -g --version 2.1.4
```

## 產生 Model

從 Database 產生 Model

```bash
dotnet ef dbcontext scaffold "server=192.168.88.85;uid=root;pwd=root;database=radius" Pomelo.EntityFrameworkCore.MySql -o Models -f -c DbContext
```

從 Model 產生 Controll 與 View

```bash
dotnet aspnet-codegenerator controller -name RadCheckController -actions -m RadCheck -dc DatabaseContext -outDir Controllers -udl
```