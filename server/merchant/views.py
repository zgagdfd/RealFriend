from django.http import HttpResponse
from rest_framework import generics
from rest_framework.utils import json

from .models import Merchant
from .serializers import MerchantSerializer


class MerchantList(generics.ListAPIView):
    queryset = Merchant.objects.all()
    serializer_class = MerchantSerializer


class MerchantDetail(generics.RetrieveUpdateAPIView):
    queryset = Merchant.objects.all()
    serializer_class = MerchantSerializer
    lookup_field = 'pk'


class MerchantCreate(generics.CreateAPIView):
    serializer_class = MerchantSerializer
