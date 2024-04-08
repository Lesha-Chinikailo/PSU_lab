using Grpc.Core;
using GrpcServiceApp;
using System.ComponentModel;


namespace pract_4_gRPCServer.Services
{
    public class MessengerService: Messenger.MessengerBase
    {
        string[] messages = { "Misha", "Dima", "Lesha", "Sergey", "Sasha", "Alesya" };
        public override async Task ServerDataStream(Request request,
            IServerStreamWriter<Response> responseStream,
            ServerCallContext context)
        {
            foreach (var message in messages)
            {
                await responseStream.WriteAsync(new Response { Content = message });

                await Task.Delay(TimeSpan.FromSeconds(2));
            }
        }
    }
}
