# !/usr/bin/python3
# -*- coding: utf-8 -*-

from django.test import RequestFactory
from django.test import TestCase

from .views import UserList
from .models import User


class TestModel(TestCase):
    pass


class TestView(TestCase):

    def setUp(self):
        self.factory = RequestFactory()
        self.user_acmore = User.objects.create(
            username='acmore', passwd='acmore',
            nickname='acmore', gender='boy',
            email='acmoretxj@163.com', phone='13031158798',
            avatar='http://img1.imgtn.bdimg.com/it/u=3742948713,2733458390&fm=27&gp=0.jpg',
            signature='身在朝堂心念武')
        self.user_ferris = User.objects.create(
            username='ferris', passwd='ferris',
            nickname='ferris', gender='boy',
            email='ferris@163.com', phone='13031158798',
            avatar='http://img1.imgtn.bdimg.com/it/u=3742948713,2733458390&fm=27&gp=0.jpg',
            signature='身在朝堂心念武')
        self.user_rachel = User.objects.create(
            username='rachel', passwd='rachel',
            nickname='rachel', gender='girl',
            email='rachel@163.com', phone='13031158798',
            avatar='http://img1.imgtn.bdimg.com/it/u=3742948713,2733458390&fm=27&gp=0.jpg',
            signature='身在朝堂心念武')

    def test_user_list(self):
        request = self.factory.get('/user')
        response = UserList.as_view()(request)
        self.assertEqual(response.status_code, 200)
