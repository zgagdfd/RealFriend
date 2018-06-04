# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from django.urls import path

from . import views

app_name = 'activity'
urlpatterns = [
    path('', views.ActivityList.as_view(), name='activities'),
    path('<int:pk>', views.ActivityDetail.as_view(), name='detail'),
    path('create', views.ActivityCreate.as_view(), name='create'),
    # 发起评论
    path('<int:activity_id>/comment', views.comment, name='comment'),
    # 获取评论列表
    path('<int:activity_id>/comments', views.CommentList.as_view(), name='comments'),
]
