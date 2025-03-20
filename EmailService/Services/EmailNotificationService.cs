using Grpc.Core;
using GrpcServer;

namespace EmailService.Services;

public class EmailNotificationService : GrpcServer.EmailNotificationService.EmailNotificationServiceBase
{
    private readonly IEmailSender _emailSender;

    public EmailNotificationService(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public override Task<MessageResponse> SendBookingConfirmation(BookingConfirmationRequest request, ServerCallContext context)
    {
        var subject = "Your Booking Confirmation";
        var body = $"Dear {request.GuestName}, Thank you for booking!\n\n" +
                         $"Hotel: {request.HotelName}\n" +
                         $"Room Number: {request.RoomNumber}\n" +
                         $"Check-in Date: {request.CheckInDate}\n" +
                         $"Check-out Date: {request.CheckOutDate}\n\n" +
                         $"We look forward to welcoming you!\n\n" +
                         "The Hotel Team";

        try
        {
            _emailSender.SendEmail(request.GuestEmail, subject, body);
            return Task.FromResult(new MessageResponse { Message = "success" });
        }
        catch (Exception ex)
        {
            return Task.FromResult(new MessageResponse { Message = "error" });
        }

    }
}