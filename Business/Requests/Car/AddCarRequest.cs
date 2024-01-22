namespace Business.Requests.Car;

public class AddCarRequest
{
    public string Plate { get; set; }

    public AddCarRequest(string plate )
    {
        Plate = plate;
    }
}
