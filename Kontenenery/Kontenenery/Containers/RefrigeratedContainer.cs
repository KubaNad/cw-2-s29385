namespace Kontenenery.Containers;

public class RefrigeratedContainer: Container
{
    public string? Product { get; set; }
    public RefrigeratedContainer(double height, double tareWeight, double maxPayload) 
        : base(height, tareWeight, maxPayload)
    {
    }

    public override string ContainerType => "C";
    public void LoadCargo(double cargoMass, string product)
    {
        if (Product == null)
        {
            Product = product;
        }

        if (string.Equals(Product, product, StringComparison.OrdinalIgnoreCase))
        {
            if (cargoMass>MaxPayload)
            {
                throw new OverfillException();
            }
            CargoMass = cargoMass;
        }
        else
        {
            throw new ArgumentException("The container can only store product of one type");
        }
        
        
        Console.WriteLine($"Załadowano {cargoMass} kg do kontenera {SerialNumber}.");
    }
}