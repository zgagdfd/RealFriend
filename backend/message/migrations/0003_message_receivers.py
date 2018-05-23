# Generated by Django 2.0.5 on 2018-05-23 07:05

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('user', '0005_auto_20180517_1406'),
        ('message', '0002_message_read'),
    ]

    operations = [
        migrations.AddField(
            model_name='message',
            name='receivers',
            field=models.ManyToManyField(null=True, related_name='messages', to='user.User'),
        ),
    ]
