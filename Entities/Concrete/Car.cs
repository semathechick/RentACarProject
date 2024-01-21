

namespace Entities.Concrete
{
    public class Car
    {
        public int Id {  get; set; }   
        public int ColorId { get; set; }    
        public int ModelId { get; set; }
        public string CarState { get; set; }

        public int Kilometer { get; set; }
        public short? ModelYear { get; set; }
        public int? Plate { get; set; }

    }
}
