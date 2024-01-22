using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using System;


namespace Business.BusinessRules
{
    public class ModelBusinessRules
    {
        private readonly IModelDal _modelDal;
        
        public ModelBusinessRules(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public void IfModelBusinessRulesExists(string name)
        {
            bool isExists = _modelDal.GetList().Any(b=> b.Name== name);
            if (isExists) 
            {
                throw new BusinessException("Model name already exists.");
            }
        }

        public void CheckModelNameLength(string name)
        {
            int modelNameLength = name.Length;
            if (modelNameLength <= 1) 
            {
                throw new BusinessException("Model name is too short.");
            }
        }
    }
}
