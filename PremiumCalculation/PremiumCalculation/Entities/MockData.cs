using PremiumCalculation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculation.Entities
{
    public class MockData
    {
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public DateTime EmployeeJoinDate { get; set; }
        public int Age { get; set; }
        public GenderEnum Gender { get; set; }
        public PricingModelEnum PricingModel { get; set; }
        public ProrateMethodEnum ProrateMethod { get; set; }
    }
}
