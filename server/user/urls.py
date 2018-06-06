# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from django.urls import path

from . import views

app_name = 'user'
urlpatterns = [
    path('', views.UserList.as_view(), name='users'),
    path('<str:username>/', views.UserDetail.as_view(), name='detail'),
    path('<str:username>/followers/', views.FollowerList.as_view(),
         name='followers'),
    path('<str:username>/followees/', views.FolloweeList.as_view(),
         name='followees'),
    path('<str:username>/friendship/<str:friend>',
         views.FriendshipDetail.as_view(), name='friendship'),
    path('create', views.UserCreate.as_view(), name='create'),
    path('login', views.login, name='login'),
    path('<str:username>/follow/<str:friend>', views.follow, name='follow'),
]
