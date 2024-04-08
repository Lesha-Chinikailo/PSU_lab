using Grpc.Core;
using Grpc.Net.Client;
using GrpcClientApp;

using var channel = GrpcChannel.ForAddress("https://localhost:7059/");

var client = new Messenger.MessengerClient(channel);

var serverData = client.ServerDataStream(new Request());

var responseStream = serverData.ResponseStream;

//while(await responseStream.MoveNext(new CancellationToken()))
//{
//    Response response = responseStream.Current;
//    Console.WriteLine(response.Content);
//}
int count = 0;
await foreach(var response in responseStream.ReadAllAsync())
{
    Console.WriteLine($"worker {++count}: {response.Content}");
}
Console.WriteLine("that's all");
Console.ReadKey();