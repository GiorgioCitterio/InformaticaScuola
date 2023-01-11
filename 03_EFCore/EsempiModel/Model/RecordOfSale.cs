
namespace EsempiModel.Model;

public class RecordOfSale
{
    public int RecordOfSaleId { get; set; }
    public DateTime DateSold { get; set; }
    public decimal Price { get; set; }
    public string CarState { get; set; }
    public string CarLicensePlate { get; set; }
    public Car1 Car1 { get; set; }
}
