# Generated by Django 2.0.5 on 2018-05-22 03:19

from django.db import migrations, models
import django.db.models.deletion
import django.utils.timezone


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('user', '0005_auto_20180517_1406'),
    ]

    operations = [
        migrations.CreateModel(
            name='Activity',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('title', models.CharField(max_length=36)),
                ('is_private', models.BooleanField(default=False)),
                ('type', models.CharField(choices=[('default', '自定义活动'), ('food', '吃吃喝喝'), ('movie', '看电影'), ('game', '游戏'), ('outdoor', '户外活动')], default='default', max_length=16)),
                ('status', models.CharField(choices=[('not_start', '还未开始'), ('in_progress', '正在进行'), ('finished', '已经结束')], default='not_start', max_length=16)),
                ('introduction', models.TextField(max_length=512)),
                ('start_time', models.DateTimeField()),
                ('end_time', models.DateTimeField()),
                ('create_time', models.DateTimeField(default=django.utils.timezone.now)),
                ('initiator', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='initiated_activities', to='user.User')),
                ('participants', models.ManyToManyField(related_name='participated_activities', to='user.User')),
            ],
        ),
    ]