using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class TransmissionBusinessRules
{
    private readonly ITransmissionDal _transmissionDal;

    public TransmissionBusinessRules(ITransmissionDal transmission)
    {
        _transmissionDal = transmission;
    }

    public void CheckTransmissionTypeName(string transmissionType)
    {
        List<string> transmissionTypes = new() { "Automatic", "Manual" };
        bool isContain = transmissionTypes.Contains(transmissionType);
        if (!isContain)
        {
            throw new Exception("Invalid Transmission Type...");
        }

    }
}

