using EducationAPI.Models.Review;
using EducationAPI.Models;
using EducationAPI.Data.Entities;




namespace EducationAPI.Services
{
    public interface IReviewServices
    {
        Task CreateReviewAsync(CreateReveiwDTO createReveiwDTO);
        Task DeleteReviewAsync(int reviewID);
        Task<IEnumerable<ReviewDTO>> GetAllReviewAsync(string? searchPhrase, string? direction);
        Task<ReviewDTO> GetReviewByIDAsync(int reviewID);
        Task UpdateReviewAsync(UpdateReviewDTO updateReviewDTO, int reviewID);
    }
}