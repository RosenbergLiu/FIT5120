using System.ComponentModel.DataAnnotations;

namespace MainProject.Data
{
    public class FoodFormViewModel
    {
        public int? CerealsId { get; set; }
        public int CerealsAmount { get; set; }

        public int? FruitsId { get; set; }
        public int FruitsAmount { get; set; }

        public int? MeatsId { get; set; }
        public int MeatsAmount { get; set; }

        public int? OilsId { get; set; }
        public int OilsAmount { get; set; }

        public FoodFormViewModel() {
            CerealsId = MeatsId = FruitsId = OilsId = null;
            CerealsAmount = MeatsAmount = FruitsAmount = OilsAmount = 0;
        }
    }
}
