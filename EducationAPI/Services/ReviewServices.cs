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


        public ReviewServices(IMapper mapper, IBaseRepository<Review> reviewRepository, IBaseRepository<Material> materialRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _materialRepository = materialRepository;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewAsync(string? searchPhrase, string? direction)
        {
            if (direction != null) direction = direction.ToLower();
            if (direction != null && direction != "asc" && direction != "desc") throw new ResourceNotFoundException("Not correct direction");

            var reviews = await _reviewRepository.GetAllAsync(searchPhrase, direction);
            var reviewDTO = _mapper.Map<List<ReviewDTO>>(reviews);
            return reviewDTO;
        }

        public async Task<ReviewDTO> GetReviewByIDAsync(int reviewID)
        {
            var review = await _reviewRepository.GetSingleAsync(A => A.ReviewID == reviewID);
            if (review is null) throw new ResourceNotFoundException($"Review with ID {reviewID} not found");

            var reviewDTO = _mapper.Map<ReviewDTO>(review);
            return reviewDTO;
        }

        public async Task<ReviewDTO> CreateReviewAsync(CreateReveiwDTO createReveiwDTO)
        {
            var newReview = _mapper.Map<Review>(createReveiwDTO);

            var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == createReveiwDTO.MaterialID);
            if (material is null) throw new ResourceNotFoundException($"Material with ID {createReveiwDTO.MaterialID} not found");

            _reviewRepository.Add(newReview);
            await _reviewRepository.SaveAsync();
            return await GetReviewByIDAsync(newReview.ReviewID);
        }

        public async Task DeleteReviewAsync(int reviewID)
        {
            var review = await _reviewRepository.GetSingleAsync(A => A.ReviewID == reviewID);
            if (review is null) throw new ResourceNotFoundException($"Review with ID {reviewID} not found");

            _reviewRepository.Delete(review);
            await _reviewRepository.SaveAsync();
        }

        public async Task<ReviewDTO> UpdateReviewAsync(UpdateReviewDTO updateReviewDTO, int reviewID)
        {
            var review = await _reviewRepository.GetSingleAsync(A => A.ReviewID == reviewID);
            if (review is null) throw new ResourceNotFoundException($"Review with ID {reviewID} not found");


            if (updateReviewDTO.Text != null) review.Text = updateReviewDTO.Text;
            if (updateReviewDTO.Rating != null) review.Rating = (uint)updateReviewDTO.Rating;

            if (updateReviewDTO.MaterialID != null)
            {
                var material = await _materialRepository.GetSingleAsync(m => m.MaterialID == updateReviewDTO.MaterialID);
                if (material is null) throw new ResourceNotFoundException($"Material with ID {updateReviewDTO.MaterialID} not found");
            }

            await _reviewRepository.SaveAsync();
            return await GetReviewByIDAsync(reviewID);
        }


    }
}
