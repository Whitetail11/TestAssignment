
using PremiumCalculation.Entities;
using PremiumCalculation.Enums;
using System.Reflection;

class Program
{
    static void Main()
    {
        var mockData = new MockData
        {
            PolicyStartDate = new DateTime(2024, 1, 1),
            PolicyEndDate = new DateTime(2024, 12, 31),
            EmployeeJoinDate = new DateTime(2024, 3, 1),
            Age = 34,
            Gender = GenderEnum.Female,
            PricingModel = PricingModelEnum.GenderAgeRated,
            ProrateMethod = ProrateMethodEnum.ProrateByDays
        };

        var calculator = new PremiumCalculator();
        var (FullPremium, ProratedPremium) = calculator.CalculatePremium(
            mockData.PolicyStartDate,
            mockData.PolicyEndDate,
            mockData.EmployeeJoinDate,
            mockData.Age,
            mockData.Gender,
            mockData.PricingModel,
            mockData.ProrateMethod);

        Console.WriteLine($"Full Premium: {FullPremium}, Prorated Premium: {ProratedPremium}");
    }
}