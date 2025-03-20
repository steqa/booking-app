using Grpc.Net.Client;
using Microsoft.Extensions.Options;

namespace backend.GRPC.Client;

public class ClientGrpcChannel
{
    public readonly GrpcChannel Channel;

    public ClientGrpcChannel(IOptions<Settings> settings)
    {
        Channel = GrpcChannel.ForAddress(settings.Value.ConnectionStrings.Http);
    }
}