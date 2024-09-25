from django.http import HttpResponseRedirect, HttpResponseNotFound
from django.shortcuts import render

from firstapp.models import Sight


def hello_world(request):
    return render(request, 'index.html', {'greeting': 'Hello, world!'})

def sights(request):
    sights = Sight.objects.all()
    return render(request, 'sights.html', context={"sights": sights})

def create(request):
    if request.method == "POST":
        sight = Sight()
        sight.name = request.POST.get("name")
        sight.location = request.POST.get("location")
        sight.type = request.POST.get("type")
        sight.description = request.POST.get("description")
        sight.save()
        return HttpResponseRedirect("/")
    else:
        return render(request, "create_sight.html")


def edit(request, id):
    try:
        sight = Sight.objects.get(id=id)
        if request.method == "POST":
            sight.name = request.POST.get("name")
            sight.location = request.POST.get("location")
            sight.type = request.POST.get("type")
            sight.description = request.POST.get("description")
            sight.save()
            return HttpResponseRedirect("/")
        else:
            return render(request, "edit_sight.html", {"sight": sight})

    except Sight.DoesNotExist:
        return HttpResponseNotFound("<h2>Album not found</h2>")

def delete(request, id):
    try:
        album = Sight.objects.get(id=id)
        album.delete()
        return HttpResponseRedirect("/")
    except:
        return HttpResponseNotFound("<h2>Album not found</h2>")
