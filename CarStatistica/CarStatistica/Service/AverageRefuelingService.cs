using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Models;

namespace CarStatistica.Service
{
    public static class AverageRefuelingService
    {

        public static List<AverageRefueling> GenerateAverageRefuelingList(List<Refueling> refuelingList)
        {
            var list = new List<AverageRefueling>();

            refuelingList = refuelingList.OrderBy(x => x.Mileage).ToList();



            for (int i = 1; i < refuelingList.Count; i++)
            {
                var averageRefueling = CalcAvg(refuelingList[i - 1], refuelingList[i]);

                list.Insert(0, new AverageRefueling(refuelingList[i].Value, refuelingList[i].Cost, refuelingList[i].Mileage, refuelingList[i].Date, refuelingList[i].Comments, averageRefueling));
            }
            return list;
        }

        private static decimal CalcAvg(Refueling earlierRefueling, Refueling lateRefueling)
        {
            return (lateRefueling.Value / (lateRefueling.Mileage - earlierRefueling.Mileage)) * 100;
        }
    }
}
