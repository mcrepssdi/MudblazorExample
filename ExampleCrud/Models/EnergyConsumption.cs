namespace ExampleCrud.Models;

public class EnergyConsumption
{
    public int Year { get; set; }
    public string Month { get; set; }
    public string State { get; set; }
    public string ProducerId { get; set; }
    public string EnergySourceUnits { get; set; }
    public string Consumption { get; set; }
}