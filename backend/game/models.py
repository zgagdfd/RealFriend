from django.db import models


name_choices = ()


class Game(models.Model):
    # 互动名称
    name = models.CharField(choices=name_choices, max_length=16)
    # TODO
