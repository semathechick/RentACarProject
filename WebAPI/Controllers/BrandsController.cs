using Business;
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

    public BrandsController(IBrandService brandService)
    {

        _brandService = brandService;


        [HttpGet]
        public GetBrandListResponse GetList([FromQuery] GetBrandListRequest request)
        {
            GetBrandListResponse response = _brandService.GetList(request);
            return response;
        }


        [HttpPost]
        public ActionResult<AddBrandResponse> Add(AddBrandRequest request)
        {
            try
            {
                AddBrandResponse response = _brandService.Add(request);


                return CreatedAtAction(nameof(GetList), response);
            }
            catch (Core.CrossCuttingConcerns.Exceptions.BusinessException exception)
            {
                return BadRequest(
                    new Core.CrossCuttingConcerns.Exceptions.BusinessProblemDetails()
                    {
                        Title = "Business Exception",
                        Status = StatusCodes.Status400BadRequest,
                        Detail = exception.Message,
                        Instance = HttpContext.Request.Path
                    }
                );

            }
        }
    }
}
