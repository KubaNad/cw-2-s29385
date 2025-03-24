namespace Kontenenery.Containers;

public class GasContainer : Container,IHazardNotifier
{
    public double Pressure { get; set; }
    public GasContainer(double height, double tareWeight, double maxPayload) 
        : base(height, tareWeight, maxPayload)
    {
    }

    public override string ContainerType => "G";
    
    public double EmptyTheCargo()
    {
        double mass = CargoMass * 0.95;
        CargoMass *=0.05;
        return mass;
    }
    
    public void HazardNotifcation(string message)
    {
        Console.WriteLine($"[ALERT] Kontener {SerialNumber}: {message}");
    }
}