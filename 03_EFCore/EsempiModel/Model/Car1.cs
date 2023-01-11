
namespace EsempiModel.Model;

public class Car1
{
    public string State { get; set; }
    public string LicensePlate { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public List<RecordOfSale> SaleHistory { get; set; }
}
