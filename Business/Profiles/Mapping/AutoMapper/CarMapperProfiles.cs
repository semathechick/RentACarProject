using AutoMapper;
using Business.Dtos.Brand;
using Business.Dtos.Car;
using Business.Requests.Brand;
using Business.Requests.Car;
using Business.Requests.Model;
using Business.Responses.Brand;
using Business.Responses.Car;
using Business.Responses.Model;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class CarMapperProfiles : Profile
{
    public CarMapperProfiles()
    {
        CreateMap<AddCarRequest, Car>();
        CreateMap<Car, AddCarResponse>();

        CreateMap<Car, CarListItemDto>();
        CreateMap<IList<Car>, GetBrandListResponse>()
            .ForMember(
                destinationMember: dest => dest.Items,
                memberOptions: opt => opt.MapFrom(mapExpression: src => src)
            );


    }
}
