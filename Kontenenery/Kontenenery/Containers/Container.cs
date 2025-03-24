namespace Kontenenery;

public abstract class Container
{
    private static int serialCounter = 0;
    public double CargoMass { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public string SerialNumber { get; set; }
    public double MaxPayload { get; set; }

    protected Container(double height, double tareWeight, double maxPayload)
    {
        CargoMass = 0;
        Height = height;
        TareWeight = tareWeight;
        MaxPayload = maxPayload;
        serialCounter++;
        SerialNumber = $"KON-{ContainerType}-{serialCounter}";
    }
    
    public abstract string ContainerType { get; }

    public double EmptyTheCargo()
    {
        CargoMass = 0;
        return CargoMass;
    }

    public void LoadCargo(double cargoMass)
    {
        if (cargoMass>MaxPayload)
        {
            throw new OverfillException();
        }
        CargoMass = cargoMass;
        Console.WriteLine($"Załadowano {cargoMass} kg do kontenera {SerialNumber}.");
    }

    public override string ToString()
    {
        return $"Kontener typu {ContainerType} [Numer seryjny: {SerialNumber}]: " +
               $"Wysokość: {Height} m, Waga własna (tara): {TareWeight} kg, " +
               $"Maksymalny ładunek: {MaxPayload} kg, Aktualny ładunek: {CargoMass} kg.";
    }

}