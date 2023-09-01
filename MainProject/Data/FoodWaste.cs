﻿using System.ComponentModel.DataAnnotations;

namespace MainProject.Data
{
    public class FoodWaste
    {
        [Key]
        public DateTime FinancialYear { get; set; }
        public double Waste { get; set; }
        public int Year { get; set; }
    }
}
