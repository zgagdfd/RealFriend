from django.http import HttpResponse
from rest_framework import generics
from rest_framework.utils import json

from .models import Game
from .serializers import GameSerializer


class GameList(generics.ListAPIView):
    queryset = Game.objects.all()
    serializer_class = GameSerializer


class GameDetail(generics.RetrieveUpdateDestroyAPIView):
    queryset = Game.objects.all()
    serializer_class = GameSerializer
    lookup_field = 'pk'


class GameCreate(generics.CreateAPIView):
    serializer_class = GameSerializer
