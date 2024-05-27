using PremiumCalculation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PremiumCalculation.Entities
{
    public class PremiumCalculator
    {
        // Add more values for older employees
        private static readonly int[] AgeMultipliers = { 100, 200, 300, 400, 500 };

        public (double FullPremium, double ProratedPremium) CalculatePremium(
            DateTime policyStartDate,
            DateTime policyEndDate,
            DateTime employeeJoinDate,
            int age,
            GenderEnum gender,
            PricingModelEnum pricingModel,
            ProrateMethodEnum prorateMethod)
        {
            ValidateDates(policyStartDate, policyEndDate, employeeJoinDate);
            double fullPremium = pricingModel switch
            {
                PricingModelEnum.FlatRate => CalculateFlatRate(),
                PricingModelEnum.AgeRated => CalculateAgeRated(age),
                PricingModelEnum.GenderAgeRated => CalculateGenderAgeRated(age, gender),
                _ => throw new ArgumentException("Invalid pricing model")
            };

            double proratedPremium = prorateMethod switch
            {
                ProrateMethodEnum.ProrateByDays => ProrateByDays(fullPremium, policyStartDate, policyEndDate, employeeJoinDate),
                ProrateMethodEnum.ProrateByMonths => ProrateByMonths(fullPremium, policyStartDate, policyEndDate, employeeJoinDate),
                _ => throw new ArgumentException("Invalid prorate method")
            };

            return (fullPremium, proratedPremium);
        }

        private void ValidateDates(DateTime policyStartDate, DateTime policyEndDate, DateTime employeeJoinDate)
        {
            if (policyEndDate <= policyStartDate)
            {
                throw new ArgumentException("Policy end date must be after the start date.");
            }

            if (employeeJoinDate < policyStartDate || employeeJoinDate > policyEndDate)
            {
                throw new ArgumentException("Employee join date must be within the policy period.");
            }
        }

        private double CalculateFlatRate()
        {
            return 1000;
        }

        private double CalculateAgeRated(int age)
        {
            int multiplier = GetAgeMultiplier(age);
            return age * multiplier;
        }

        private double CalculateGenderAgeRated(int age, GenderEnum gender)
        {
            double basePremium = CalculateAgeRated(age);

            if (gender == GenderEnum.Female && age >= 18)
            {
                basePremium *= 1.5;
            }

            return basePremium;
        }

        private int GetAgeMultiplier(int age)
        {
            if (age < 0) throw new ArgumentOutOfRangeException(nameof(age), "Age cannot be negative");

            int index = age / 10;
            if (index >= AgeMultipliers.Length)
            {
                index = AgeMultipliers.Length - 1;
            }

            return AgeMultipliers[index];
        }

        private double ProrateByDays(double fullPremium, DateTime policyStartDate, DateTime policyEndDate, DateTime employeeJoinDate)
        {
            int totalDays = (policyEndDate - policyStartDate).Days;
            int remainingDays = (policyEndDate - employeeJoinDate).Days;

            return fullPremium * remainingDays / totalDays;
        }

        private double ProrateByMonths(double fullPremium, DateTime policyStartDate, DateTime policyEndDate, DateTime employeeJoinDate)
        {
            int totalMonths = ((policyEndDate.Year - policyStartDate.Year) * 12) + policyEndDate.Month - policyStartDate.Month;
            int remainingMonths = ((policyEndDate.Year - employeeJoinDate.Year) * 12) + policyEndDate.Month - employeeJoinDate.Month;

            return fullPremium * remainingMonths / totalMonths;
        }
    }
}
