# RealFriend

- RealFriend小组
- 2018.5.22

## 1. 项目介绍

## 2. 开发准备

#### 2.1 依赖库
```shell
$ sudo apt install nginx libmysqlclient-dev virtualenv gcc g++
$ cd /path/to/RealFriend
$ virtualenv venv -p python3
$ source venv/bin/activate
$ pip install -r requirements.txt -i https://pypi.mirrors.ustc.edu.cn/simple/
```

#### 2.2 数据库
```shell
$ sudo apt install mysql-server
$ sudo mysql_secure_installation
mysql > $ CREATE DATABASE realfriend;
mysql > $ ALTER DATABASE realfriend CHARACTER SET utf8 COLLATE utf8_unicode_ci;
```
#### 2.3 工具包
#### 2.4 用户验证
项目使用了`rest_framework`内置的验证机制，验证方法是令牌验证，使用的方法如下：

1. 首先在settings.py中添加
```python
REST_FRAMEWORK = {
    'DEFAULT_PERMISSION_CLASSES': (
        'rest_framework.permissions.IsAuthenticated',
    ),
    'DEFAULT_AUTHENTICATION_CLASSES': (
        'rest_framework.authentication.TokenAuthentication',
    ),
}
```
2. 在settings.py的INSTALLED_APPS中添加`'rest_framework.authtoken'`
3. 添加获取Token的view（这里添加在了根APP的views.py中）
4. 开发阶段默认Token不打开，因此将`REST_FRAMEWORK`中的`'rest_framework.permissions.IsAuthenticated'`改成`'rest_framework.permissions.AllowAny'`

## 3. 部署准备

## 4. 改进方向
- 获取实体列表时，不要获取所有字段
