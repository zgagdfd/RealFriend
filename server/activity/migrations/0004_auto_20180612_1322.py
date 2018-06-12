# Generated by Django 2.0.5 on 2018-06-12 05:22

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('activity', '0003_activity_merchant'),
    ]

    operations = [
        migrations.AlterField(
            model_name='activity',
            name='merchant',
            field=models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, related_name='activities', to='merchant.Merchant'),
        ),
    ]