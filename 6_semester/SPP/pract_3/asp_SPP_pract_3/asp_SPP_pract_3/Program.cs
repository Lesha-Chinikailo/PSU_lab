using asp_SPP_pract_3.Models;
using System.Configuration;
using System;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Azure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();


//using (var db = new TrainContext("Server=DESKTOP-501ABTG;Database=TrainsDateBase;Trusted_Connection=True;TrustServerCertificate=true;"))
//{
//    Carriage carriage1 = new Carriage()
//    {
//        CarriageId = 6,
//        NumberOfSeats = 20,
//        TrainId = 6
//    };
//    Train train = new Train()
//    {
//        TrainName = "test123",
//        //TrainId = 6
//    };
//    db.Trains.Add(train);
//    //db.Carriages.Add(carriage1);
//    db.SaveChanges();
//}



app.MapGet("/", () => "Hello World!");

app.MapGet("/info", async (context) =>
{
    using (var db = new TrainContext("Server=DESKTOP-501ABTG;Database=TrainsDateBase;Trusted_Connection=True;TrustServerCertificate=true;"))
    {
        List<Train> trains = db.Trains.ToList();
        foreach(var train in trains)
        {
            await context.Response.WriteAsync($"Train: name: {train.TrainName} Id: {train.TrainId}\n");
        }
        
    }
});

//app.MapGet("/trains", async (context) =>
//{

//});

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.Run();
