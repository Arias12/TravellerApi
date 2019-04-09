using AutoMapper;
using TravellerApi.Model;
using TravellerApi.ModelDTO;

namespace TravellerApi
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<InterestingPlace, InterestingPlaceDTO>().ReverseMap();
        }
    }
}