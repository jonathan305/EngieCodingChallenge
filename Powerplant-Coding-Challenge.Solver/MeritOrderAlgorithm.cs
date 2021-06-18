using Powerplant_Coding_Challenge.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Powerplant_Coding_Challenge.Solver
{
    /// <summary>
    /// Calculate how much power each of a multitude of different powerplants 
    /// need to produce (a.k.a. the production-plan) when the load is given 
    /// and taking into account the cost of the underlying energy sources (gas, kerosine) 
    /// and the Pmin and Pmax of each powerplant.
    /// </summary>
    public class MeritOrderAlgorithm:  IPowerPlantProductionPlanAlgorithm
    {

        public List<PowerplantProductionResponse> CalculatePowerPlantProductionPlan(Payload payload)
        {
            // TODO:  Perform checks on the input to ensure that payload is valid before running algorithm
            


            List<PowerplantProductionResponse> productionPlan = new List<PowerplantProductionResponse>();

            decimal load = payload.Load;

            // Let's get the minimum each powerplant produces
            foreach (Powerplant powerPlant in payload.Powerplants)
            {
                productionPlan.Add(new PowerplantProductionResponse(powerPlant.Name, powerPlant.Pmin));
            }

            // Let's calculate the sum of minimum load each PowerPlant produces
            decimal pMinSum = productionPlan.Sum(pp => pp.P);

            // Does the pMinSum exceed the payload.Load amount?  
            //If so done???

            decimal leftToProduce = load - pMinSum;

            // Wind is most efficent is it optimal to treat this Powersource as the first choice?  i think so.
            // Get maximum wind turbine Pmax 
            // Wind - turbines do not consume 'fuel' and thus are considered to generate power at zero price.
            foreach (Powerplant powerplant in payload.Powerplants.Where(pp => pp.Type == "windturbine").OrderByDescending(pp => pp.Efficiency))
            {
                // We subtract the Min because this has already been accounted for
                decimal windAdditionalProductionCapacity = (((decimal)payload.Fuels.Wind / 100) / (decimal)powerplant.Efficiency * powerplant.Pmax) - powerplant.Pmin;

                PowerplantProductionResponse response = productionPlan.Where(pp => pp.Name == powerplant.Name).First();
                if (windAdditionalProductionCapacity >= leftToProduce)
                {
                    response.P += (decimal)leftToProduce;
                    leftToProduce -= leftToProduce;
                    break;
                }
                else
                {
                    response.P += (decimal)windAdditionalProductionCapacity;
                    leftToProduce -= windAdditionalProductionCapacity;
                }
            }

            // now which is more efficient gasfired or turbojet
            // TODO:  account for CO2 emissions
            List<(Powerplant, decimal)> powerplantCostPerMWh = new List<(Powerplant, decimal)>();

            foreach (Powerplant powerplant in
                        payload.Powerplants.Where(pp => pp.Type == "gasfired" || pp.Type == "turbojet"))
            {
                if (powerplant.Type == "gasfired")
                {
                    decimal costMWh = payload.Fuels.GasEuroMWh / powerplant.Efficiency;
                    powerplantCostPerMWh.Add((powerplant, costMWh));
                }
                else if (powerplant.Type == "turbojet")
                {
                    decimal costMWh = payload.Fuels.KerosineEuroMWh / powerplant.Efficiency;
                    powerplantCostPerMWh.Add((powerplant, costMWh));
                }
            }

            foreach ((Powerplant, double) ppEfficiency in powerplantCostPerMWh.OrderBy(ppe => ppe.Item2))
            {
                decimal additionalProductionCapacity = ppEfficiency.Item1.Pmax - ppEfficiency.Item1.Pmin;
                PowerplantProductionResponse response = productionPlan.Where(pp => pp.Name == ppEfficiency.Item1.Name).First();
                if (additionalProductionCapacity >= leftToProduce)
                {
                    response.P += leftToProduce;
                    leftToProduce -= leftToProduce;
                    break;
                }
                else
                {
                    response.P += additionalProductionCapacity;
                    leftToProduce -= additionalProductionCapacity;
                }
            }

            return productionPlan;
        }
    }
}
