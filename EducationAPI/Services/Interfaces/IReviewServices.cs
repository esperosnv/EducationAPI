using EducationAPI.Models.Review;

namespace EducationAPI.Services
{
    public interface IReviewServices
    {
        Task<ReviewDTO> CreateReviewAsync(CreateReveiwDTO createReveiwDTO);
        Task DeleteReviewAsync(int reviewID);
        Task<IEnumerable<ReviewDTO>> GetAllReviewAsync(string? searchPhrase, string? direction);
        Task<ReviewDTO> GetReviewByIDAsync(int reviewID);
        Task<ReviewDTO> UpdateReviewAsync(UpdateReviewDTO updateReviewDTO, int reviewID);
        Task<ReviewDTO> PutReviewAsync(PutReviewDTO putReviewDTO, int reviewID);
    }
}