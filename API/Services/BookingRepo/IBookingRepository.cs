﻿using API.DTOs;
using API.Models;
using Stripe;
using WebApiDotNet.Repos;

namespace API.Services.BookingRepo
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<(IEnumerable<Booking> bookings, int totalCount)> GetAllBookingForProperty(int propertyId, int page = 1, int pageSize = 10);
        Task<(IEnumerable<Booking> bookings, int totalCount)> GetAllUserBooking(string userId, int page = 1, int pageSize = 10);
        Task<Booking> getBookingByIdWithData(int bookingId);
        Task<IEnumerable<Booking>> GetBookingsByGuestAndPropertyAsync(string userId, int propertyId);
        Task<Booking> GetBookingByPropertyandUserAsync(string userId, int propertyId);
        Task<IEnumerable<Booking>> GetPropertyBookingDetails(int propertyId);
        Task<Booking> GetUserBookingetails(int bookingId);
        Task<bool> IsPropertyAvailableForBookingAsync(int propertyId, DateTime startDate, DateTime endDate);
        Task CreateBookingAndUpdateAvailabilityAsync(Booking booking);
        Task UpdateBookingAndUpdateAvailabilityAsync(Booking booking, DateTime oldStartDate, DateTime oldEndDate);
        Task DeleteBookingAndUpdateAvailabilityAsync(int id);
        Task<IEnumerable<Booking>> GetAllBookingsAsync(int hostId);
        Task<DateTime?> GetLastAvailableDateForPropertyAsync(int propertyId);
        Task<bool> IsBookingOwnedByHostAsync(int bookingId, int hostId);
        Task<bool> UpdateBookingStatusAsync(int bookingId, string newStatus);

        Task<PropertyDto> getPropertyByIdAsync(int propertyId);
        //Task<Property> GetPropertyWithDetailsAsync(int propertyId);

        Task<Promotion> GetPromotionByIdAsync(int promotionId);
        Task<bool> IsPromotionValidForBookingAsync(int promotionId, int guestId, DateTime bookingStartDate);
        Task AddUserUsedPromotionAsync(UserUsedPromotion usedPromotion);
        Task<int> GetPromotionIdByCodeAsync(string promoCode);
        Task<decimal> GetTotalIncomeForHostAsync(int hostId);
        Task<decimal> GetTotalSpentByGuestAsync(int guestId);

        Task<PaymentIntent> CreatePaymentIntentAsync(decimal amount, int bookingId);
    }
}