using GrpcClient;

namespace backend.GRPC.Client;

public class EmailNotificationClient
{
    private readonly EmailNotificationService.EmailNotificationServiceClient _client;
    
    public EmailNotificationClient(ClientGrpcChannel grpcChannel)
    {
        _client = new EmailNotificationService.EmailNotificationServiceClient(grpcChannel.Channel);
    }
    
    public async Task<MessageResponse> SendBookingConfirmationAsync(
        string guestName,
        string guestEmail,
        string hotelName,
        string roomNumber,
        string checkInDate,
        string checkOutDate)
    {
        var result = await _client.SendBookingConfirmationAsync(new BookingConfirmationRequest
        {
            GuestName = guestName,
            GuestEmail = guestEmail,
            HotelName = hotelName,
            RoomNumber = roomNumber,
            CheckInDate = checkInDate,
            CheckOutDate = checkOutDate,
        });
        
        return result;
    }
}