using ApplicationLayer.DTOs;
using ApplicationLayer.DTOs.MediatR;
using ApplicationLayer.Interfaces;
using ApplicationLayer.ReviewCommand_Query_Handler.ReviewCommand;
using AutoMapper;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.ReviewCommand_Query_Handler.ReviewHandler
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, OperationResult<ReviewDTO>>
    {
        private readonly IGenericRepository<Review> _reviewRepository;
        private readonly IGenericRepository<Restaurant> _restaurantRepository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(
            IGenericRepository<Review> reviewRepository,
            IGenericRepository<Restaurant> restaurantRepository,
            IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<ReviewDTO>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            // Hämta restaurangen baserat på namn
            var restaurant = await _restaurantRepository.FirstOrDefaultAsync(
                r => r.Name == request.ReviewDto.RestaurantName, cancellationToken);

            if (restaurant == null)
            {
                return OperationResult<ReviewDTO>.Failure("Restaurang hittades inte");
            }

            // Mappa DTO -> Entity
            var review = _mapper.Map<Review>(request.ReviewDto);

            review.RestaurantId = restaurant.RestaurantId;
            review.UserId = 1; // TODO: Hämta från inloggad användare via Auth om möjligt
            review.ReviewDate = DateTime.UtcNow;

            // Spara recensionen
            await _reviewRepository.AddAsync(review);
            await _reviewRepository.SaveChangesAsync();

            // Mappa tillbaka till DTO och returnera
            var result = _mapper.Map<ReviewDTO>(review);
            return OperationResult<ReviewDTO>.Success(result, "Recension skapades!");
        }
    }
}
