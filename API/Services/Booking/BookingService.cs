using backend.Exceptions.Booking;
using backend.GRPC.Client;
using backend.Repositories.Booking;
using backend.Schemas.Booking;
using backend.Services.Guest;
using backend.Services.Hotel;
using backend.Services.Room;

namespace backend.Services.Booking;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IGuestService _guestService;
    private readonly IRoomService _roomService;
    private readonly IHotelService _hotelService;
    private readonly EmailNotificationClient _emailNotificationClient;
    
    public BookingService(
        IBookingRepository bookingRepository,
        IGuestService guestService,
        IRoomService roomService,
        IHotelService hotelService,
        EmailNotificationClient emailNotificationClient)
    {
        _bookingRepository = bookingRepository;
        _guestService = guestService;
        _roomService = roomService;
        _hotelService = hotelService;
        _emailNotificationClient = emailNotificationClient;
    }

    public async Task<SBookingResponse> CreateBooking(SBookingCreate data)
    {
        var guest = await _guestService.GetGuest(data.GuestId);
        var room = await _roomService.GetRoom(data.RoomId);
        var hotel = await _hotelService.GetHotel(room.HotelId);
        
        var booking = await _bookingRepository.CreateBooking(new Models.Booking
        {
            GuestId = guest.Id,
            RoomId = room.Id,
            CheckIn = data.CheckIn,
            CheckOut = data.CheckOut,
        });

        await _emailNotificationClient.SendBookingConfirmationAsync(
            guestName: guest.FirstName,
            guestEmail: guest.Email,
            hotelName: hotel.Name,
            roomNumber: room.Number,
            checkInDate: booking.CheckIn.ToString("dd.MM.yyyy HH:mm"),
            checkOutDate: booking.CheckOut.ToString("dd.MM.yyyy HH:mm"));
        
        return new SBookingResponse(booking);
    }
    
    public async Task<SBookingResponse> GetBooking(long id)
    {
        var booking = await _bookingRepository.GetBooking(new BookingFilter { Id = id });
        if (booking == null)
            throw new EHttpBookingNotFound();
      
        return new SBookingResponse(booking);
    }
    
    public async Task<SBookingResponse[]> GetBookings()
    {
        var bookings = await _bookingRepository.GetBookings();
        
        return bookings.Select(booking => new SBookingResponse(booking)).ToArray();
    }
    
    public async Task<SBookingResponse> UpdateBooking(long id, SBookingUpdate data)
    {
        var guest = await _guestService.GetGuest(data.GuestId);
        var room = await _roomService.GetRoom(data.RoomId);
        
        var booking = await _bookingRepository.GetBooking(new BookingFilter { Id = id });
        if (booking == null)
            throw new EHttpBookingNotFound();

        booking.GuestId = guest.Id;
        booking.RoomId = room.Id;
        booking.CheckIn = data.CheckIn;
        booking.CheckOut = data.CheckOut;
        
        booking = await _bookingRepository.UpdateBooking(booking);
        
        return new SBookingResponse(booking);
    }

    public async Task DeleteBooking(long id)
    {
        var booking = await _bookingRepository.GetBooking(new BookingFilter { Id = id });
        if (booking == null)
            throw new EHttpBookingNotFound();
        
        await _bookingRepository.DeleteBooking(id);
    }
}