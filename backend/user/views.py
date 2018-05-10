from rest_framework import generics

from .models import User
from .serializers import UserSerializer


class FollowerList(generics.ListAPIView):
    queryset = User.objects.all()
    serializer_class = UserSerializer


class FolloweeList(generics.ListAPIView):
    queryset = User.objects.all()
    serializer_class = UserSerializer


class UserDetail(generics.RetrieveUpdateAPIView):
    queryset = User.objects.all()
    serializer_class = UserSerializer
    lookup_field = 'username'
