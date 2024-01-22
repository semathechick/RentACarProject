namespace Business.Responses.Car;

public class AddCarResponse
{
    public int Id { get; set; }
  

    public short ModelYear { get; set; }
    public int Plate { get; set; }

    public AddCarResponse(int id,  int plate, short modelYear )
    {
        Id = id;
        Plate = plate;
        ModelYear = modelYear;
    }
}
