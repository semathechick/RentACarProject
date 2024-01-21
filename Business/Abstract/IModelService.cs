﻿
using Business.Requests.Model;
using Business.Responses.Model;

namespace Business.Abstract
{
    public interface IModelService
    {
        public AddModelResponse Add(AddModelRequest request);
        public GetBrandListResponse GetBrandList(GetBrandListRequest request);
    }
}
