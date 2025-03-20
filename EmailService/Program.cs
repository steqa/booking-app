using EmailService;
using EmailService.Services;
using EmailService.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEmailSender, SmtpEmailSender>();

builder.Services.AddGrpc();

builder.Configuration.AddJsonFile("Settings/smtp_settings.json", optional: false, reloadOnChange: true);
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

var app = builder.Build();

app.MapGrpcService<EmailNotificationService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();