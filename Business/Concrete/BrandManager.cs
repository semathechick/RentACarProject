using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brand;
using Business.Responses.Brand;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;
    private readonly BrandBusinessRules _brandBusinessRules;
    private readonly IMapper _mapper;

    public BrandManager(IBrandDal brandDal, BrandBusinessRules brandBusinessRules, IMapper mapper)
    {
        _brandDal = brandDal;
        _brandBusinessRules = brandBusinessRules;
        _mapper = mapper;
    }

    public AddBrandResponse Add(AddBrandRequest request)
    {

        _brandBusinessRules.CheckIfBrandNameNotExists(request.Name);

        Brand brandToAdd = _mapper.Map<Brand>(request);

        _brandDal.Add(brandToAdd);

        AddBrandResponse response = _mapper.Map<AddBrandResponse>(brandToAdd);
        return response;
    }

    public AddBrandResponse Delete(int id)
    {
        Brand brand = _brandBusinessRules.FindBrandWithId(id);
        brand.DeletedAt = DateTime.Now;
        AddBrandResponse brandResponse = _mapper.Map<AddBrandResponse>(brand);
        return brandResponse;
    }

    
    public IList<Brand> GetList()
    {


        IList<Brand> brandList = _brandDal.GetList();
        return brandList;
    }
}
