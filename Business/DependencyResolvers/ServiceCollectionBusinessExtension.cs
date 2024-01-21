using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers;

public static class ServiceCollectionBusinessExtension
{
  
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services
            .AddSingleton<IBrandService, BrandManager>()
            .AddSingleton<IBrandDal, InMemoryBrandDal>()
            .AddSingleton<BrandBusinessRules>(); 


        services
            .AddSingleton<IModelService, ModelManager>()
            .AddSingleton<IModelDal, InMemoryModelDal>()
            .AddSingleton<ModelBusinessRules>();

        services
            .AddSingleton<ICarService, CarManager>()
            .AddSingleton<ICarDal, InMemoryCarDal>()
            .AddSingleton<CarBusinessRules>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly()); 

        return services;
    }
}
