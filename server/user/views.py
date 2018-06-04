from django.http import HttpResponse
from rest_framework import generics
from rest_framework.utils import json

from .models import User, Friendship, Follower, Followee
from .serializers import UserSerializer, FriendShipSerializer, \
    FolloweeSerializer, FollowerSerializer


class UserList(generics.ListAPIView):
    queryset = User.objects.all()
    serializer_class = UserSerializer


class UserDetail(generics.RetrieveUpdateAPIView):
    queryset = User.objects.all()
    serializer_class = UserSerializer
    lookup_field = 'username'


# TODO：用户创建没有密码，以及没有登录操作
class UserCreate(generics.CreateAPIView):
    serializer_class = UserSerializer


class FollowerList(generics.ListAPIView):
    serializer_class = FollowerSerializer

    def get_queryset(self):
        username = self.kwargs['username']
        results = Follower.objects.filter(user__username=username)
        return results


class FolloweeList(generics.ListAPIView):
    serializer_class = FolloweeSerializer

    def get_queryset(self):
        username = self.kwargs['username']
        results = Followee.objects.filter(user__username=username)
        return results


def follow(request, username, friend):
    from_user = User.objects.get(username=username)
    to_user = User.objects.get(username=friend)
    follower = Follower(user=to_user, username=from_user.username,
                        nickname=from_user.nickname, gender=from_user.gender,
                        avatar=from_user.avatar, signature=from_user.signature)
    follower.save()
    followee = Followee(user=from_user, username=to_user.username,
                        nickname=to_user.nickname, gender=to_user.gender,
                        avatar=to_user.avatar, signature=to_user.signature)
    followee.save()
    response = {'status': 'success'}
    return HttpResponse(json.dumps(response), content_type='application/json')


# TODO: 用户好友度实体的创建

class FriendshipDetail(generics.RetrieveUpdateAPIView):
    serializer_class = FriendShipSerializer

    def get_object(self):
        user = self.kwargs['username']
        friend = self.kwargs['friend']
        results = Friendship.objects.filter(main_user__username=user) \
            .filter(sub_user__username=friend)
        return results[0] if results else None
