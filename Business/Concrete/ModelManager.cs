using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Brand;
using Business.Requests.Car;
using Business.Requests.Model;
using Business.Responses.Car;
using Business.Responses.Fuel;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Business.Concrete;

public class ModelManager : IModelService
{
    private readonly IModelDal _modelDal;
    private readonly ModelBusinessRules _modelBusinessRules;
    private readonly IMapper _mapper;

    public ModelManager(IModelDal modelDal, ModelBusinessRules modelBusinessRules, IMapper mapper)
    {
        _modelDal = modelDal;
        _modelBusinessRules = modelBusinessRules;
        _mapper = mapper;
    }

    public AddModelResponse Add(AddModelRequest request)
    {

        _modelBusinessRules.IfModelBusinessRulesExists(name);
        _modelBusinessRules.CheckModelNameLength(name);                 

        Model modelToAdd = _mapper.Map<Model>(request);
        _modelDal.Add(modelToAdd);

        AddCarResponse response = _mapper.Map<AddCarResponse>(request.Plate);
        return response;
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {


        IList<Model> modelList = _modelDal.GetList();



        GetModelListResponse response = _mapper.Map<GetModelListResponse>(modelList);
        return response;
    }
}