# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from rest_framework import serializers

from .models import Game


class GameSerializer(serializers.ModelSerializer):
    class Meta:
        model = Game
        fields = ('id', 'name', 'initiator', 'participants', 'is_private',
                  'status', 'create_time', 'start_time', 'type', 'introduction')
