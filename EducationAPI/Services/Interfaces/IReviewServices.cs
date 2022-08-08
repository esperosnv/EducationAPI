using EducationAPI.Models.Review;

namespace EducationAPI.Services
{
    public interface IReviewServices
    {
        Task CreateReviewAsync(CreateReveiwDTO createReveiwDTO);
        Task DeleteReviewAsync(int reviewID);
        Task<IEnumerable<ReviewDTO>> GetAllReviewAsync(string searchPhrase);
        Task<ReviewDTO> GetReviewByIDAsync(int reviewID);
        Task UpdateReviewAsync(UpdateReviewDTO updateReviewDTO, int reviewID);
    }
}