# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from django.urls import path

from . import views

app_name = 'game'
urlpatterns = [
    path('', views.GameList.as_view(), name='games'),
    path('<int:pk>', views.GameDetail.as_view(), name='detail'),
    path('create', views.GameCreate.as_view(), name='create')
]
