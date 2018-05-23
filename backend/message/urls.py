# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from django.urls import path

from . import views

app_name = 'message'
urlpatterns = [
    path('', views.MessageList.as_view(), name='messages'),
    path('create', views.MessageCreate.as_view(), name='create'),
    path('read/<int:message_id>', views.read, name='read'),
]
