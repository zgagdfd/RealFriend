from django.db import models
from django.utils.timezone import now


type_choices = (('food', '食品类'), ('movie', '电影类'),
                ('game', '游戏类'), ('tourism', '旅行类'))


class Merchant(models.Model):
    # 商家名称
    name = models.CharField(max_length=16, unique=True)
    # 商家分类
    type = models.CharField(choices=type_choices, max_length=16)
    # 商家图片
    image = models.URLField()
    # 商家描述
    introduction = models.TextField(max_length=512)
    # 商家信息，存储json格式的数据
    info = models.TextField(default='{}')
    # 创建时间
    create_time = models.DateTimeField(default=now)
