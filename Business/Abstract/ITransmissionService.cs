using Business.Requests.Transmission;
using Business.Responses.Transmision;

namespace Business.Abstract;

public interface ITransmissionService
{
    public AddTransmissionResponse Add(AddTransmissionRequest request);

    public GetTransmissionListResponse GetList(GetTransmissionListRequest request);
}
