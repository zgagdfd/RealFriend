from django.http import HttpResponse
from rest_framework import generics
from rest_framework.utils import json

from .models import Activity, Comment
from .serializers import ActivitySerializer, CommentSerializer


class ActivityList(generics.ListAPIView):
    queryset = Activity.objects.all()
    serializer_class = ActivitySerializer


class ActivityDetail(generics.RetrieveUpdateAPIView):
    queryset = Activity.objects.all()
    serializer_class = ActivitySerializer
    lookup_field = 'pk'


class ActivityCreate(generics.CreateAPIView):
    serializer_class = ActivitySerializer


def comment(request, activity_id):
    activity = Activity.objects.get(id=activity_id)
    cmt = activity.comments.create(
        nickname=request.POST['nickname'],
        username=request.POST['username'],
        content=request.POST['content']
    )
    message = {'status': 'success', 'comment_id': cmt.id}
    return HttpResponse(json.dumps(message), content_type='application/json')


class CommentList(generics.ListAPIView):
    queryset = Comment.objects.all()
    serializer_class = CommentSerializer

    def get_queryset(self):
        activity_id = self.kwargs['activity_id']
        results = Comment.objects.filter(activity__id=activity_id)
        return results
