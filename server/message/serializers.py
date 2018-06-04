# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from rest_framework import serializers

from .models import Message


class MessageSerializer(serializers.ModelSerializer):
    class Meta:
        model = Message
        fields = ('id', 'receivers', 'type', 'title', 'priority',
                  'sender', 'content', 'create_time', 'read')
