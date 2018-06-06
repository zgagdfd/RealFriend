# !/usr/bin/python3
# -*- coding: utf-8 -*-

from django.test import TestCase
from rest_framework.test import APIRequestFactory
from rest_framework.utils import json

from .views import UserList, UserDetail, UserCreate, login
from .models import User


class TestModel(TestCase):
    pass


class TestView(TestCase):

    def setUp(self):
        self.factory = APIRequestFactory()
        self.user_acmore = User.objects.create(
            username='acmore', passwd='acmore',
            nickname='acmore', gender='boy',
            email='acmoretxj@163.com', phone='13031158798',
            avatar='http://img1.imgtn.bdimg.com/it/u=3742948713,2733458390&fm=27&gp=0.jpg',
            signature='身在朝堂心念武')
        self.user_ferris = User.objects.create(
            username='ferris', passwd='ferris',
            nickname='ferris', gender='boy',
            email='ferris@163.com', phone='13031158799',
            avatar='http://img1.imgtn.bdimg.com/it/u=3742948713,2733458390&fm=27&gp=0.jpg',
            signature='身在朝堂心念武')
        self.user_rachel = User.objects.create(
            username='rachel', passwd='rachel',
            nickname='rachel', gender='girl',
            email='rachel@163.com', phone='13031158700',
            avatar='http://img1.imgtn.bdimg.com/it/u=3742948713,2733458390&fm=27&gp=0.jpg',
            signature='身在朝堂心念武')
        self.users = (self.user_acmore, self.user_ferris, self.user_rachel)
        self.keys = ('username', 'nickname', 'gender', 'email', 'phone', 'avatar', 'signature')

    def test_user_list(self):
        request = self.factory.get('/user')
        response = UserList.as_view()(request)
        response.render()
        response = json.loads(response.content)
        for key in self.keys:
            # noinspection PyUnusedLocal
            values1 = {eval('user.%s' % key) for user in self.users}
            values2 = {resp[key] for resp in response}
            self.assertEqual(values1, values2)

    def test_user_detail(self):
        for user in self.users:
            request = self.factory.get('/user')
            response = UserDetail.as_view()(request, username=user.username)
            response.render()
            response = json.loads(response.content)
            for key in self.keys:
                self.assertEqual(response[key], eval('user.%s' % key))

    def test_user_create(self):
        data = {
            'username': 'anonymous',
            'nickname': 'anonymous',
            'passwd': 'anonymous',
            'gender': 'boy',
            'email': 'anonymous@163.com',
            'phone': '10000000000',
            'avatar': 'http://img1.imgtn.bdimg.com/it/u=3742948713,2733458390&fm=27&gp=0.jpg',
            'signature': '一夜花落两成空'
        }
        request = self.factory.post('/user/create', data=data)
        response = UserCreate.as_view()(request)
        response.render()
        self.assertEqual(response.status_code, 201)
        # noinspection PyUnusedLocal
        new_user = User.objects.get(username=data['username'])
        for key in self.keys:
            self.assertEqual(data[key], eval('new_user.%s' % key))

    def test_login(self):
        data = {
            'username': self.user_acmore.username,
            'password': self.user_acmore.passwd
        }
        request = self.factory.post('/user/login', data=data)
        response = login(request)
        self.assertEqual(response.status_code, 200)
        response = json.loads(response.content)
        self.assertTrue(response['status'] == 'success')

        data = {
            'username': self.user_acmore.username,
            'password': self.user_acmore.passwd + '_wrong'
        }
        request = self.factory.post('/user/login', data=data)
        response = login(request)
        self.assertEqual(response.status_code, 200)
        response = json.loads(response.content)
        self.assertTrue(response['status'] == 'password wrong')

        data = {
            'username': self.user_acmore.username + '_wrong',
            'password': self.user_acmore.passwd + '_wrong'
        }
        request = self.factory.post('/user/login', data=data)
        response = login(request)
        self.assertEqual(response.status_code, 200)
        response = json.loads(response.content)
        self.assertTrue(response['status'] == 'user not exists')
