using AutoMapper;
using EducationAPI.Data.DAL.Interfaces;
using EducationAPI.Data.Entities;
using EducationAPI.Models.MaterialType;
using EducationAPI.Data.Exceptions;
using EducationAPI.Data.Entities;
using EducationAPI.Models.Review;
using EducationAPI.Models;


namespace EducationAPI.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Review> _reviewRepository;
        private readonly IBaseRepository<Material> _materialRepository;
        private readonly ILogger<ReviewServices> _logger;



        public ReviewServices(IMapper mapper, IBaseRepository<Review> reviewRepository, IBaseRepository<Material> materialRepository, ILogger<ReviewServices> logger)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _materialRepository = materialRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewAsync(string? searchPhrase, string? direction)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to get all reviews");

            if (direction != null) direction = direction.ToLower();
            if (direction != null && direction != "asc" && direction != "desc") throw new ResourceNotFoundException("Not correct direction");

            var reviews = await _reviewRepository.GetAllAsync(searchPhrase, direction);
            var reviewDTO = _mapper.Map<List<ReviewDTO>>(reviews);
            return reviewDTO;
        }

        public async Task<ReviewDTO> GetReviewByIDAsync(int reviewID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to get review with id {reviewID}");

            var review = await _reviewRepository.GetSingleAsync(A => A.ReviewID == reviewID);
            if (review is null) throw new ResourceNotFoundException($"Review with ID {reviewID} not found");

            var reviewDTO = _mapper.Map<ReviewDTO>(review);
            return reviewDTO;
        }

        public async Task<ReviewDTO> CreateReviewAsync(CreateReveiwDTO createReveiwDTO)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to create a new review");

            var newReview = _mapper.Map<Review>(createReveiwDTO);

            var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == createReveiwDTO.MaterialID);
            if (material is null) throw new ResourceNotFoundException($"Material with ID {createReveiwDTO.MaterialID} not found");

            _reviewRepository.Add(newReview);
            await _reviewRepository.SaveAsync();
            return await GetReviewByIDAsync(newReview.ReviewID);
        }

        public async Task DeleteReviewAsync(int reviewID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Request to delete a review with id {reviewID}");

            var review = await _reviewRepository.GetSingleAsync(A => A.ReviewID == reviewID);
            if (review is null) throw new ResourceNotFoundException($"Review with ID {reviewID} not found");

            _reviewRepository.Delete(review);
            await _reviewRepository.SaveAsync();
        }

        public async Task<ReviewDTO> UpdateReviewAsync(UpdateReviewDTO updateReviewDTO, int reviewID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Patch request to update review with id {reviewID}");

            var review = await _reviewRepository.GetSingleAsync(A => A.ReviewID == reviewID);
            if (review is null) throw new ResourceNotFoundException($"Review with ID {reviewID} not found");


            if (updateReviewDTO.Text != null) review.Text = updateReviewDTO.Text;
            if (updateReviewDTO.Rating != null) review.Rating = (int)updateReviewDTO.Rating;

            if (updateReviewDTO.MaterialID != null)
            {
                var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == updateReviewDTO.MaterialID);
                if (material is null) throw new ResourceNotFoundException($"Material with ID {updateReviewDTO.MaterialID} not found");
                review.MaterialID = (int)updateReviewDTO.MaterialID;
            }

            await _reviewRepository.SaveAsync();
            return await GetReviewByIDAsync(reviewID);
        }


        public async Task<ReviewDTO> PutReviewAsync(PutReviewDTO putReviewDTO, int reviewID)
        {
            _logger.LogInformation($"{DateTime.UtcNow} UTC - Put request to update review with id {reviewID}");

            var review = await _reviewRepository.GetSingleAsync(A => A.ReviewID == reviewID);
            if (review is null) throw new ResourceNotFoundException($"Review with ID {reviewID} not found");

            review.Text = putReviewDTO.Text;
            review.Rating = (int)putReviewDTO.Rating;
          
            var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == putReviewDTO.MaterialID);
            if (material is null) throw new ResourceNotFoundException($"Material with ID {putReviewDTO.MaterialID} not found");
            review.MaterialID = putReviewDTO.MaterialID;
            

            await _reviewRepository.SaveAsync();
            return await GetReviewByIDAsync(reviewID);
        }


    }
}
