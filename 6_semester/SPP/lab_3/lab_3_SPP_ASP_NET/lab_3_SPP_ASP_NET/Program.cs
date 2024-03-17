using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;
using System.Text.Json;

using System.Text.RegularExpressions;
using System.Xml.Linq;
using lab_3_SPP_ASP_NET.Models;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;


var _db = new TrainsDateBaseContext();
List<Train> trains = _db.Trains.ToList();
//List<Train> trains = new List<Train>()
//{
//    new Train{TrainId = 0, TrainName = "train 0" },
//    new Train{TrainId = 1, TrainName = "train 1" },
//    new Train{TrainId = 2, TrainName = "train 2" },
//};

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.Run(async (context) =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;
    //string expressionForNumber = "^/api/trains/([0-9]+)$";   // если id представляет число

    // 2e752824-1657-4c7f-844b-6ec2e168e99c
    string expressionForGuid = @"^/api/trains/[0-9]*$";
    if (path == "/api/trains" && request.Method == "GET")
    {
        await GetAllTrain(response);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "GET")
    {
        // получаем id из адреса url
        int? id = int.Parse(path.Value?.Split("/")[3]);
        await GetTrain(id, response);
    }
    else if (path == "/api/trains" && request.Method == "POST")
    {
        await CreateTrain(response, request);
    }
    else if (path == "/api/trains" && request.Method == "PUT")
    {
        await UpdateTrain(response, request);
    }
    else if (Regex.IsMatch(path, expressionForGuid) && request.Method == "DELETE")
    {
        int? id = int.Parse(path.Value?.Split("/")[3]);
        await DeleteTrain(id, response);
    }
    else
    {
        response.ContentType = "text/html; charset=utf-8";
        await response.SendFileAsync("html/index.html");
    }
});

app.Run();

// получение всех пользователей
async Task GetAllTrain(HttpResponse response)
{
    await response.WriteAsJsonAsync(trains);
}
// получение одного пользователя по id
async Task GetTrain(int? id, HttpResponse response)
{
    // получаем пользователя по id
    Train? train = trains.FirstOrDefault((u) => u.TrainId == id);
    // если пользователь найден, отправляем его
    if (train != null)
        await response.WriteAsJsonAsync(train);
    // если не найден, отправляем статусный код и сообщение об ошибке
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "Поезд не найден" });
    }
}

async Task DeleteTrain(int? id, HttpResponse response)
{
    // получаем пользователя по id
    Train? train = trains.FirstOrDefault((t) => t.TrainId == id);
    // если пользователь найден, удаляем его
    if (train != null)
    {
        _db.Trains.Remove(train);
        _db.SaveChanges();
        trains = await _db.Trains.ToListAsync();
        //trains.Remove(train);
        await response.WriteAsJsonAsync(train);
    }
    // если не найден, отправляем статусный код и сообщение об ошибке
    else
    {
        response.StatusCode = 404;
        await response.WriteAsJsonAsync(new { message = "train не найден" });
    }
}

async Task CreateTrain(HttpResponse response, HttpRequest request)
{
    try
    {
        // получаем данные пользователя
        var train = await request.ReadFromJsonAsync<Train>();
        if (train != null)
        {
            //train.TrainId = trains.Count == 0 ? 0 : trains.Last().TrainId + 1;//_db.Trains.ToList().Last().TrainId;

            _db.Trains.Add(train);
            _db.SaveChanges();
            await response.WriteAsJsonAsync(train);
        }
        else
        {
            throw new Exception("Некорректные данные");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
    }
    finally
    {
        trains = await _db.Trains.ToListAsync();
    }
}

async Task UpdateTrain(HttpResponse response, HttpRequest request)
{
    try
    {
        // получаем данные пользователя
        Train? trainData = await request.ReadFromJsonAsync<Train>();
        if (trainData != null)
        {
            // получаем пользователя по id
            var train = trains.FirstOrDefault(t => t.TrainId == trainData.TrainId);
            // если пользователь найден, изменяем его данные и отправляем обратно клиенту
            if (train != null)
            {
                train.TrainName = trainData.TrainName;
                _db.Trains.Where(t => t.TrainId == train.TrainId).Single().TrainName = trainData.TrainName;
                _db.SaveChanges();
                await response.WriteAsJsonAsync(train);
            }
            else
            {
                response.StatusCode = 404;
                await response.WriteAsJsonAsync(new { message = "Пользователь не найден" });
            }
        }
        else
        {
            throw new Exception("Некорректные данные");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
    }
    finally
    {
        trains = await _db.Trains.ToListAsync();
    }
}
