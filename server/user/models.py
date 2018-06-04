from django.db import models
from django.utils.timezone import now


gender_choices = (('boy', '男'), ('girl', '女'))


class User(models.Model):
    # 用户名
    username = models.CharField(max_length=16, unique=True)
    # 密码SHA256结果
    passwd = models.CharField(max_length=64)
    # 用户昵称
    nickname = models.CharField(max_length=16)
    # 用户性别
    gender = models.CharField(choices=gender_choices, max_length=8)
    # 用户电子邮箱
    email = models.EmailField(unique=True)
    # 用户手机号码
    phone = models.CharField(max_length=11, unique=True)
    # 用户头像链接
    avatar = models.URLField()
    # 用户签名
    signature = models.CharField(default='', max_length=64)
    # 用户其他信息,存储在Json格式字符串中
    info = models.TextField(default='{}')
    # 用户注册时间
    create_time = models.DateTimeField(default=now)


class Followee(models.Model):
    # 关注人表所属的用户
    user = models.ForeignKey('User', on_delete=models.CASCADE,
                             related_name='followees')
    # 关注人用户名
    username = models.CharField(max_length=16)
    # 关注人昵称
    nickname = models.CharField(max_length=16)
    # 用户性别
    gender = models.CharField(choices=gender_choices, max_length=8)
    # 关注人头像链接
    avatar = models.URLField()
    # 关注人签名
    signature = models.CharField(default='', max_length=64)


class Follower(models.Model):
    # 粉丝表所属的用户
    user = models.ForeignKey('User', on_delete=models.CASCADE,
                             related_name='followers')
    # 粉丝用户名
    username = models.CharField(max_length=16)
    # 粉丝昵称
    nickname = models.CharField(max_length=16)
    # 粉丝性别
    gender = models.CharField(choices=gender_choices, max_length=8)
    # 粉丝头像链接
    avatar = models.URLField()
    # 粉丝签名
    signature = models.CharField(default='', max_length=64)


class Friendship(models.Model):
    """
    友好度数据表,这里的双方用户不必是关注和被关注的关系
    """
    # 友好度的甲方
    main_user = models.ForeignKey('User', on_delete=models.CASCADE,
                                  related_name='main_friendships')
    # 友好度的乙方
    sub_user = models.ForeignKey('User', on_delete=models.CASCADE,
                                 related_name='sub_friendships')
    # 友好度数值
    degree = models.IntegerField(default=0)
