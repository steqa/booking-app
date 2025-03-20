namespace backend.GRPC.Client;

public class Settings
{
    public required SConnectionString ConnectionStrings { get; set; }

    public class SConnectionString
    {
        public required string Http { get; set; }
    }
}