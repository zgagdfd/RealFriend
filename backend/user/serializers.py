# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from rest_framework import serializers

from .models import User


class UserSerializer(serializers.ModelSerializer):
    class Meta:
        model = User
        fields = ('id', 'username', 'nickname', 'gender', 'email', 'phone',
                  'avatar', 'signature', 'info', 'create_time')
