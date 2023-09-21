using System.ComponentModel.DataAnnotations;

namespace FoodSaver.Data;

public class FoodWasteModel
{
    [Key]
    public DateTime FinancialYear { get; set; }
    public double Waste { get; set; }
    public int Year { get; set; }
}