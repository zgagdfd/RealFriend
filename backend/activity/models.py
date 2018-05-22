from django.db import models
from django.utils.timezone import now

# noinspection PyUnresolvedReferences
from user.models import User


type_choices = (('default', '自定义活动'), ('food', '吃吃喝喝'),
                ('movie', '看电影'), ('game', '游戏'),
                ('outdoor', '户外活动'))
status_choices = (('not_start', '还未开始'), ('in_progress', '正在进行'),
                  ('finished', '已经结束'))


class Activity(models.Model):
    # 活动发起人
    initiator = models.ForeignKey(User, on_delete=models.CASCADE,
                                  related_name='initiated_activities')
    # 活动的标题
    title = models.CharField(max_length=36)
    # TODO: 活动涉及的商家
    pass
    # 活动的参与人员
    participants = models.ManyToManyField(User, related_name='participated_activities')
    # 活动是否对非相关用户可见
    is_private = models.BooleanField(default=False)
    # 活动的类型
    type = models.CharField(choices=type_choices, default=type_choices[0][0],
                            max_length=16)
    # 活动的状态
    status = models.CharField(choices=status_choices, default=status_choices[0][0],
                              max_length=16)
    # 活动描述
    introduction = models.TextField(max_length=512)
    # 活动开始的时间
    start_time = models.DateTimeField()
    # 活动结束的时间
    end_time = models.DateTimeField()
    # 发起活动的时间
    create_time = models.DateTimeField(default=now)
