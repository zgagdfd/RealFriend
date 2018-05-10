from datetime import datetime

from django.db import models


class User(models.Model):
    # 用户名
    username = models.CharField(max_length=16)
    # 密码SHA256结果
    passwd = models.CharField(max_length=64)
    # 用户昵称
    nickname = models.CharField(max_length=16)
    # 用户性别,True代表女性,False代表男性
    gender = models.BooleanField(default=False)
    # 用户电子邮箱
    email = models.EmailField()
    # 用户手机号码
    phone = models.CharField(max_length=11)
    # 用户头像链接
    avatar = models.URLField()
    # 用户签名
    signature = models.CharField(default='', max_length=64)
    # 用户其他信息,存储在Json格式字符串中
    info = models.TextField(default='{}')
    # 用户注册时间
    create_time = models.DateTimeField(default=datetime.now())
