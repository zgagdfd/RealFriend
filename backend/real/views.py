from django.contrib.auth import authenticate
from django.http import HttpResponse
from rest_framework.utils import json
from rest_framework.authtoken.models import Token


def get_token(request):
    username, password = request.POST['username'], request.POST['password']
    user = authenticate(username=username, password=password)
    if not user: return HttpResponse('user is not exists', status=404)
    token, _ = Token.objects.get_or_create(user=user)
    response = {
        'status': 'success',
        'token': token.key,
    }
    return HttpResponse(json.dumps(response), content_type='application/json')
