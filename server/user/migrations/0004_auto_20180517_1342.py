# Generated by Django 2.0.5 on 2018-05-17 13:42

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('user', '0003_auto_20180517_1324'),
    ]

    operations = [
        migrations.AlterField(
            model_name='user',
            name='followees',
            field=models.ManyToManyField(null=True, related_name='_user_followees_+', to='user.User'),
        ),
        migrations.AlterField(
            model_name='user',
            name='followers',
            field=models.ManyToManyField(null=True, related_name='_user_followers_+', to='user.User'),
        ),
    ]
