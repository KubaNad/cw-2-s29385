using System.Text;

namespace Kontenenery.ContainerShips;

public class ContainerShip
{
    public List<Container> ContainersOnShip { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxNumberOfContainers { get; set; }
    public double MaxWeight { get; set; } 

    public ContainerShip()
    {
        ContainersOnShip = new List<Container>();
    }
    
    public bool CanAddContainer(Container container)
    {
        if (ContainersOnShip.Count >= MaxNumberOfContainers)
        {
            return false;
        }

        double totalWeight = ContainersOnShip.Sum(c => c.CargoMass + c.TareWeight);
        if (totalWeight + container.CargoMass + container.TareWeight > MaxWeight)
        {
            return false;
        }

        return true;
    }
    
    public void LoadContainer(Container container)
    {
        if (!CanAddContainer(container))
        {
            Console.WriteLine($"Nie można załadować kontenera {container.SerialNumber}: przekroczono limity statku.");
            return;
        }

        ContainersOnShip.Add(container);
        Console.WriteLine($"Załadowano kontener {container.SerialNumber} na statek.");
    }
    
    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }
    
    public bool RemoveContainer(string serialNumber)
    {
        var container = ContainersOnShip.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            ContainersOnShip.Remove(container);
            Console.WriteLine($"Usunięto kontener {serialNumber} ze statku.");
            return true;
        }

        Console.WriteLine($"Kontener {serialNumber} nie został znaleziony na statku.");
        return false;
    }
    
    public bool ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = ContainersOnShip.FindIndex(c => c.SerialNumber == serialNumber);
        if (index == -1)
        {
            Console.WriteLine($"Kontener {serialNumber} nie został znaleziony na statku.");
            return false;
        }

        // Sprawdzenie, czy po zastąpieniu nie przekroczymy limitu wagi
        double currentTotalWeight = ContainersOnShip.Sum(c => c.CargoMass + c.TareWeight);
        var oldContainer = ContainersOnShip[index];
        currentTotalWeight -= (oldContainer.CargoMass + oldContainer.TareWeight);
        if (currentTotalWeight + newContainer.CargoMass + newContainer.TareWeight > MaxWeight)
        {
            Console.WriteLine("Nie można zastąpić kontenera: przekroczono dopuszczalną wagę statku.");
            return false;
        }

        ContainersOnShip[index] = newContainer;
        Console.WriteLine($"Kontener {serialNumber} został zastąpiony kontenerem {newContainer.SerialNumber}.");
        return true;
    }

    // Przeniesienie kontenera między dwoma statkami (usuwa z bieżącego i dodaje do statku docelowego)
    public bool TransferContainer(string serialNumber, ContainerShip destinationShip)
    {
        var container = ContainersOnShip.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            Console.WriteLine($"Kontener {serialNumber} nie został znaleziony na bieżącym statku.");
            return false;
        }

        if (!destinationShip.CanAddContainer(container))
        {
            Console.WriteLine(
                $"Nie można przenieść kontenera {serialNumber} do docelowego statku: przekroczono limity.");
            return false;
        }

        ContainersOnShip.Remove(container);
        destinationShip.ContainersOnShip.Add(container);
        Console.WriteLine($"Kontener {serialNumber} został przeniesiony do docelowego statku.");
        return true;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("=== Dane statku ===");
        sb.AppendLine($"Maksymalna prędkość: {MaxSpeed} km/h");
        sb.AppendLine($"Maksymalna liczba kontenerów: {MaxNumberOfContainers}");
        sb.AppendLine($"Maksymalna waga statku: {MaxWeight} kg");
        sb.AppendLine($"Aktualnie załadowanych kontenerów: {ContainersOnShip.Count}");
    
        double currentTotalWeight = ContainersOnShip.Sum(c => c.CargoMass + c.TareWeight);
        sb.AppendLine($"Aktualna waga załadowanych kontenerów: {currentTotalWeight} kg");
    
        sb.AppendLine("--- Lista kontenerów ---");
        foreach (var container in ContainersOnShip)
        {
            sb.AppendLine($"Serial: {container.SerialNumber}, Masa ładunku: {container.CargoMass} kg, Masa opakowania: {container.TareWeight} kg");
        }
    
        return sb.ToString();
    }

    
}