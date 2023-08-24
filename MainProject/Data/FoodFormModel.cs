namespace MainProject.Data
{
    public class FoodFormModel
    {
        public int? VegetableId { get; set; }
        public int VegetableAmount { get; set; }
        public int? FruitsId { get; set; }
        public int FruitsAmount { get; set; }
        public int? MeatId { get; set; }
        public int MeatAmount { get; set; }
        public int? OtherId { get; set; }
        public int OtherAmount { get; set; }

        public FoodFormModel() {
            VegetableId = MeatId = FruitsId = OtherId = null;
            VegetableAmount = MeatAmount = FruitsAmount = OtherAmount = 0;
        }
    }
}
