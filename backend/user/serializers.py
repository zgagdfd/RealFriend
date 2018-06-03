# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from rest_framework import serializers

from .models import User, Friendship, Follower, Followee


class UserSerializer(serializers.ModelSerializer):
    class Meta:
        model = User
        fields = ('id', 'username', 'passwd', 'nickname', 'gender', 'email', 'phone',
                  'avatar', 'signature', 'info', 'create_time')


class FollowerSerializer(serializers.ModelSerializer):
    class Meta:
        model = Follower
        fields = ('user', 'username', 'nickname', 'gender', 'avatar',
                  'signature')


class FolloweeSerializer(serializers.ModelSerializer):
    class Meta:
        model = Followee
        fields = ('user', 'username', 'nickname', 'gender', 'avatar',
                  'signature')


class FriendShipSerializer(serializers.ModelSerializer):
    class Meta:
        model = Friendship
        fields = ('main_user', 'sub_user', 'degree')
