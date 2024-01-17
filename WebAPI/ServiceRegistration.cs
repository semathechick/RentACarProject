using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Business.Requests.Fuel;
using Business.Requests.Brand;
using Business.Responses.Brand;
using Business.Responses.Fuel;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace WebAPI;

public static class ServiceRegistration
{
    public static readonly IFuelDal FuelDal = new InMemoryFuelDal();

    public static readonly FuelBusinessRules FuelBusinessRules = new FuelBusinessRules(FuelDal);

    public static IMapper Mapper = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<AddFuelRequest, Fuel>();
        cfg.CreateMap<Fuel, AddFuelResponse>();
   
    
        cfg.CreateMap<AddBrandRequest, Brand>();
        cfg.CreateMap<Brand, AddBrandResponse>();
    }).CreateMapper();

    public static readonly IFuelService FuelService = new FuelManager(
        FuelDal,
        FuelBusinessRules,
        Mapper
    );

    public static readonly IBrandDal BrandDal = new InMemoryBrandDal();

    public static readonly BrandBusinessRules BrandBusinessRules = new BrandBusinessRules(BrandDal);

    
    public static readonly IBrandService BrandService = new BrandManager(
        BrandDal,
        BrandBusinessRules,
        Mapper
    );

}
