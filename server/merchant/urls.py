# !/usr/bin/env python3
# -*- coding: utf-8 -*-
from django.urls import path

from . import views

app_name = 'merchant'
urlpatterns = [
    path('', views.MerchantList.as_view(), name='merchants'),
    path('<int:pk>', views.MerchantDetail.as_view(), name='detail'),
    path('create', views.MerchantCreate.as_view(), name='create'),
]
