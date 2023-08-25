using System.ComponentModel.DataAnnotations;

namespace MainProject.Data
{
    public class FoodFormModel
    {
        public int? VegetablesId { get; set; }
        public int VegetablesAmount { get; set; }

        public int? FruitsId { get; set; }
        public int FruitsAmount { get; set; }

        public int? MeatsId { get; set; }
        public int MeatsAmount { get; set; }

        public int? OthersId { get; set; }
        public int OthersAmount { get; set; }

        public FoodFormModel() {
            VegetablesId = MeatsId = FruitsId = OthersId = null;
            VegetablesAmount = MeatsAmount = FruitsAmount = OthersAmount = 0;
        }
    }
}
