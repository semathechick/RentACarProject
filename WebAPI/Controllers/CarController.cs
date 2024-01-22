using Business;
using Business.Abstract;
using Business.Concrete;
using Business.Requests.Brand;
using Business.Requests.Car;
using Business.Responses.Brand;
using Business.Responses.Car;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public GetCarListResponse GetList([FromQuery] GetCarListRequest request)
        {
            GetCarListResponse response = _carService.GetList(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddCarResponse> Add(AddCarRequest request)
        {
            try
            {
                AddCarResponse response = _carService.Add(request);
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

