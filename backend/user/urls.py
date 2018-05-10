# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from django.urls import path

from . import views

app_name = 'user'
urlpatterns = [
    path('<str:username>/', views.UserDetail.as_view()),
    path('<str:username>/followers/', views.FollowerList.as_view()),
    path('<str:username>/followees/', views.FolloweeList.as_view())
]
