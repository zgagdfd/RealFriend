# Generated by Django 2.0.5 on 2018-05-23 08:16

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('message', '0003_message_receivers'),
    ]

    operations = [
        migrations.AlterField(
            model_name='message',
            name='receivers',
            field=models.ManyToManyField(related_name='messages', to='user.User'),
        ),
    ]
