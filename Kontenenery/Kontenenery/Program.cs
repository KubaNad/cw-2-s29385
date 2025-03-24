// Tworzenie statków

using Kontenenery;
using Kontenenery.Containers;
using Kontenenery.ContainerShips;

ContainerShip ship1 = new ContainerShip
{
    MaxSpeed = 25,
    MaxNumberOfContainers = 5,
    MaxWeight = 30000
};

ContainerShip ship2 = new ContainerShip
{
    MaxSpeed = 20,
    MaxNumberOfContainers = 3,
    MaxWeight = 15000
};

// Tworzenie kontenerów
RefrigeratedContainer refContainer = new RefrigeratedContainer(250, 2000, 8000);
refContainer.LoadCargo(5000, "Banany");

LiquidContainer liquidContainer = new LiquidContainer(260, 2100, 9000);
liquidContainer.LoadCargo(8000, isHazardous: false);

GasContainer gasContainer = new GasContainer(240, 1900, 7000);
gasContainer.LoadCargo(6500);

// Załadowanie pojedynczych kontenerów na ship1
ship1.LoadContainer(refContainer);
ship1.LoadContainer(liquidContainer);
ship1.LoadContainer(gasContainer);

// Załadowanie listy dodatkowych kontenerów na ship1
List<Container> extraContainers = new List<Container>
{
    new LiquidContainer(265, 2200, 8500),
    new RefrigeratedContainer(255, 2100, 7500)
};
((LiquidContainer)extraContainers[0]).LoadCargo(7000, isHazardous: false);
((RefrigeratedContainer)extraContainers[1]).LoadCargo(6000, "Mleko");
ship1.LoadContainers(extraContainers);

// Usunięcie kontenera (gasContainer) ze ship1
ship1.RemoveContainer(gasContainer.SerialNumber);

// Zastąpienie kontenera na ship1 – zastępujemy refContainer nowym kontenerem chłodniczym
RefrigeratedContainer newRefContainer = new RefrigeratedContainer(250, 2000, 8000);
newRefContainer.LoadCargo(4500, "Banany");
ship1.ReplaceContainer(refContainer.SerialNumber, newRefContainer);

// Przeniesienie kontenera (liquidContainer) ze ship1 do ship2
ship1.TransferContainer(liquidContainer.SerialNumber, ship2);

// Wypisanie informacji o statkach i ich ładunku
Console.WriteLine("\n--- Informacje o statku ship1 ---");
Console.WriteLine(ship1.ToString());
Console.WriteLine("\n--- Informacje o statku ship2 ---");
Console.WriteLine(ship2.ToString());