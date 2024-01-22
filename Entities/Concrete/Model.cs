using Core.Entities;
using System.Net.Sockets;

namespace Entities.Concrete;

public class Model : Entity<int>
{
   
    public string Name { get; set; }

    public int FuelId { get; set; }

    public int TransmissionId { get; set; }
    public int ModelId { get; set; }
    public decimal? DailyPrice { get; set; }

    public Model(string name, int dailyPrice, int fuelId, int transmissionId, int modelId)
    {
        Name = name;

        DailyPrice = dailyPrice;
        FuelId = fuelId;
        TransmissionId = transmissionId;    
        ModelId = modelId;  




    }

   

  
}
