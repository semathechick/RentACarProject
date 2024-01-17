using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.BusinessRules;

public class BrandBusinessRules
{
    private readonly IBrandDal _brandDal;

    public BrandBusinessRules(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }


    public Brand FindBrandWithId(int id)
    {
        Brand brand = _brandDal.GetList().Where(e => e.Id == id).SingleOrDefault();
        return brand;
    }

    public void CheckIfBrandNameNotExists(string brandName)
    {
        bool isExists = _brandDal.GetList().Any(b => b.Name == brandName);
        if (isExists)
        {
            throw new Exception("Brand already exists.");
        }
    }
}