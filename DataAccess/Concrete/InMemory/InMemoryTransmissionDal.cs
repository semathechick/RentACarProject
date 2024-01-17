using Core.DataAccess.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory;

public class InMemoryTransmissionDal : InMemoryEntityRepositoryBase<Transmission, int>, ITransmissionDal
{
    protected override int generateId()
    {
        throw new NotImplementedException();
    }
}
