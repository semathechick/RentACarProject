using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules
{
    public class CarBusinessRules
    {
        private readonly ICarDal _carDal;

        public CarBusinessRules(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void IfCarModelYearIsValid(string carModelYear)
        {
            if (int.TryParse(carModelYear, out int modelYear))
            {
                int currentYear = DateTime.Now.Year;
                int age = currentYear - modelYear;

                if (age >= 20)
                {
                    throw new BusinessException("Car Age is too old...");
                }
            }
        }
}   }
