# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from rest_framework import serializers

from .models import Merchant


class MerchantSerializer(serializers.ModelSerializer):
    class Meta:
        model = Merchant
        fields = ('id', 'name', 'type', 'image', 'introduction',
                  'info', 'create_time')
