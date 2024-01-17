using Core.Entities;

namespace Entities.Concrete;

public class Transmission : Entity<int>
{
    public int FuelId { get; set; }
    public string Name { get; set; }
    public short Year { get; set; }

    public Transmission? Transmisson { get; set; } = null;
}
