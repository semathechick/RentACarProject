

using DataAccess.Abstract;

namespace Business.BusinessRules
{
    public class FuelBusinessRules
    {
        private readonly IFuelDal _fuelDal;

        public FuelBusinessRules(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }
        public void CheckFuelTypeName(string fuelType)
        {
            List<string> fuelTypes = new() { "LPG", "Diesel", "electricity" };
            bool isContain = fuelTypes.Contains(fuelType);
            if (!isContain)
            {
                throw new Exception("Invalid Transmission Type...");
            }

        }
    }
