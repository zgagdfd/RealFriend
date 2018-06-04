# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from rest_framework import serializers

from .models import Game


class GameSerializer(serializers.ModelSerializer):
    class Meta:
        model = Game
        fields = ('id', 'name')
