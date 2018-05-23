from django.http import HttpResponse
from rest_framework import generics
from rest_framework.utils import json

# noinspection PyUnresolvedReferences
from user.models import User
from .models import Message
from .serializers import MessageSerializer


class MessageList(generics.ListAPIView):
    queryset = Message.objects.all().order_by('create_time')[::-1]
    serializer_class = MessageSerializer

    def get_queryset(self):
        if 'username' in self.request.GET:
            user = User.objects.get(username=self.request.GET['username'])
            results = [message for message in user.messages.all()] + \
                      [message for message in Message.objects.filter(receivers=None)]
        else: results = Message.objects.all()
        return results


class MessageDetail(generics.RetrieveUpdateAPIView):
    queryset = Message.objects.all()
    serializer_class = MessageSerializer
    lookup_field = 'pk'


class MessageCreate(generics.CreateAPIView):
    serializer_class = MessageSerializer


def read(request, message_id):
    """
    标记某条消息为已读
    :param request: 客户端的请求
    :param message_id: 欲读消息的id
    :return:
    """
    message = Message.objects.get(id=message_id)
    message.read = True
    message.save()
    response = {'status': 'success'}
    return HttpResponse(json.dumps(response), content_type='application/json')
