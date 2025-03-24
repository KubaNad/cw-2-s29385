namespace Kontenenery;

public class LiquidContainer : Container,IHazardNotifier
{
    public LiquidContainer(double height, double tareWeight, double maxPayload) 
        : base(height, tareWeight, maxPayload)
    {
    }
    public void LoadCargo(double mass, bool isHazardous)
    {
        // Wyznaczenie maksymalnej dopuszczalnej masy w zależności od rodzaju ładunku
        double allowedCapacity = isHazardous ? 0.5 * MaxPayload : 0.9 * MaxPayload;
            
        if (mass > allowedCapacity)
        {
            string msg = $"Próba załadowania {mass} kg, co przekracza dozwoloną ilość " +
                         $"{(isHazardous ? "50%" : "90%")} maksymalnej ładowności ({allowedCapacity} kg).";
            // Wysłanie notyfikacji o niebezpiecznej operacji
            HazardNotifcation(msg);
            // Rzucenie wyjątku
            throw new OverfillException(msg);
        }
            
        CargoMass = mass;
        Console.WriteLine($"Załadowano {mass} kg do kontenera {SerialNumber} (ładunek {(isHazardous ? "niebezpieczny" : "zwykły")}).");
    }
    public override string ContainerType => "L";
    
    public void HazardNotifcation(string message)
    {
        Console.WriteLine($"[ALERT] Kontener {SerialNumber}: {message}");
    }
}