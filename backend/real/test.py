from django.contrib.auth.models import User
from django.test import RequestFactory
from django.test import TestCase
from rest_framework.authtoken.models import Token
from rest_framework.utils import json


class TestView(TestCase):

    def setUp(self):
        self.factory = RequestFactory()
        self.user = User.objects.create_user(
            username='acmore', email='acmoretxj@163.com', password='acmore')

    def tearDown(self):
        pass

    def test_get_token(self):
        from .views import get_token
        data = {
            'username': 'acmore',
            'password': 'acmore'
        }
        request = self.factory.post('/token', data=data)
        request.user = self.user
        response = get_token(request)
        token, _ = Token.objects.get_or_create(user=self.user)
        response = json.loads(response.content)
        self.assertEqual(response['token'], token.key)
