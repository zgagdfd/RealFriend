from django.db import models
from django.utils.timezone import now

# noinspection PyUnresolvedReferences
from user.models import User

type_choices = (('system', '系统通知'), ('activity', '活动消息'),
                ('game', '互动消息'), ('friend', '好友消息'))
priority_choices = ((0, '默认优先级'), (1, '一级优先级'),
                    (2, '二级优先级'), (3, '三级优先级'))


class Message(models.Model):
    # 消息类型
    type = models.CharField(choices=type_choices, max_length=16)
    # 消息接收者，如果为null则表示对所有人发送的消息
    receivers = models.ManyToManyField(User, related_name='messages')
    # 消息标题
    title = models.CharField(max_length=36)
    # 消息优先级
    priority = models.IntegerField(choices=priority_choices)
    # 发送人，如果类型是非system，则sender值为对应实体的id，
    # 默认 -1 表示系统
    sender = models.IntegerField(default=-1)
    # 消息内容
    content = models.TextField(max_length=512)
    # 消息创建时间
    create_time = models.DateTimeField(default=now)
    # 是否已读
    read = models.BooleanField(default=False)
