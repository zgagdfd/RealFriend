# Generated by Django 2.0.5 on 2018-05-23 08:32

from django.db import migrations, models
import django.utils.timezone


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Merchant',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('name', models.CharField(max_length=16)),
                ('type', models.CharField(choices=[('food', '食品类'), ('movie', '电影类'), ('game', '游戏类'), ('tourism', '旅行类')], max_length=16)),
                ('image', models.URLField()),
                ('introduction', models.TextField(max_length=512)),
                ('info', models.TextField(default='{}')),
                ('create_time', models.DateTimeField(default=django.utils.timezone.now)),
            ],
        ),
    ]
