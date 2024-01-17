using Business.Abstract;
using Business.Concrete;
using Business.Requests.Brand;
using Business.Responses.Brand;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService; 

    public BrandsController()
    {
        
        _brandService = ServiceRegistration.BrandService;
    }


    [HttpGet] 
    public ICollection<Brand> GetList()
    {
        IList<Brand> brandList = _brandService.GetList();
        return brandList;
    }


  


    [HttpPost] 
    public ActionResult<AddBrandResponse> Add(AddBrandRequest request)
    {
        AddBrandResponse response = _brandService.Add(request);

       
        return CreatedAtAction(nameof(GetList), response); 
    }
}
