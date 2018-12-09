# Radius Manager

這是一個由 ASP.net Core 撰寫的 Freeradius 管理前端。

## 開發環境設定

```bash
dotnet restore
dotnet tool install dotnet-aspnet-codegenerator -g --version 2.1.4
dotnet ef database update
```

## FreeRadius 設定

```bash
apt install freeradius freeradius-mysql

cd /etc/freeradius/3.0/mods-config/sql/main/mysql
mysql -uroot -p < setup.sql
cd /etc/freeradius/3.0/mods-available/
$EDITOR sql
## - driver = "rlm_sql_null"
## + driver = "rlm_sql_mysql"

## - dialect = "sqlite"
## + dialect = "mysql"

## - #server = "localhost"
## - #port = 3306
## - #login = "radius"
## - #password = "radpass"
## + server = "localhost"
## + port = 3306
## + login = "radius"
## + password = "radpass"

## - #logfile = ${logdir}/sqllog.sql
## + logfile = ${logdir}/sqllog.sql
cd ../mods-enabled
ln -s ../mods-available/sql sql

systemctl stop freeradius
freeradius -X &
radtest 'admin' admin localhost 0 testing123
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