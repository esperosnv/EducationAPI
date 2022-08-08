using AutoMapper;
using EducationAPI.Models.Review;
using EducationAPI.Data.Entities;

namespace EducationAPI.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDTO>()
                    .ForMember(d => d.Material, a => a.MapFrom(m => m.Material.Title));

            CreateMap<CreateReveiwDTO, Review>();

        }
    }
}
