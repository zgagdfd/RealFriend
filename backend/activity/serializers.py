# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from rest_framework import serializers

from .models import Activity, Comment


class ActivitySerializer(serializers.ModelSerializer):
    class Meta:
        model = Activity
        fields = ('id', 'initiator', 'title', 'participants', 'is_private', 'type',
                  'status', 'introduction', 'start_time', 'end_time', 'create_time')


class CommentSerializer(serializers.ModelSerializer):
    class Meta:
        model = Comment
        fields = ('id', 'nickname', 'username', 'content', 'create_time')
