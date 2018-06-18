from django.db import models
from django.utils.timezone import now
# noinspection PyUnresolvedReferences
from user.models import User

name_choices = ()
status_choices = (('not_start', '还未开始'), ('in_progress', '正在进行'),
                  ('finished', '已经结束'))


class Game(models.Model):
    # 互动名称
    name = models.CharField(choices=name_choices, max_length=16)
    # 互动发起人
    initiator = models.ForeignKey(User, default=1,
                                  on_delete=models.CASCADE, related_name='initiated_games')
    # 互动的参与人员
    participants = models.ManyToManyField(User, related_name='participated_games')
    # 互动是否对非相关用户可见
    is_private = models.BooleanField(default=False)
    # 互动的状态
    status = models.CharField(choices=status_choices, default=status_choices[0][0],
                              max_length=16)
    # 发起互动的时间
    create_time = models.DateTimeField(default=now)
