# Generated by Django 2.0.5 on 2018-06-19 01:09

from django.db import migrations, models
import django.utils.timezone


class Migration(migrations.Migration):

    dependencies = [
        ('game', '0002_auto_20180618_1512'),
    ]

    operations = [
        migrations.AddField(
            model_name='game',
            name='introduction',
            field=models.CharField(default='', max_length=256),
        ),
        migrations.AddField(
            model_name='game',
            name='start_time',
            field=models.DateTimeField(default=django.utils.timezone.now),
            preserve_default=False,
        ),
        migrations.AddField(
            model_name='game',
            name='type',
            field=models.CharField(choices=[('室内', 'indoor'), ('室外', 'outdoor'), ('线上', 'online')], default='室内', max_length=16),
        ),
    ]
