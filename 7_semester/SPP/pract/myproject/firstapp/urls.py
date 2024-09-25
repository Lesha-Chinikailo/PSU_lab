from django.urls import path
from . import views

urlpatterns = [
    path('', views.sights, name='sights'),
    # path('', views.hello_world, name='hello_world'),
    path('create/', views.create, name='create'),
    path('edit/<int:id>', views.edit),
    path('delete/<int:id>', views.delete)
]