module Program

open System
open System.Collections.Generic

type OperatingSystems = { NameOfOs: string; InfectionProbability: int }

type Computer = { operatingSystem: OperatingSystems; mutable Infected: bool }

type LocalNetwork(newNetOfComp : List<Computer>, mat : bool[,])=
    let mutable rand = new Random()
    let mutable listOfAllComputersInNet = newNetOfComp
    let mutable matrixOfLink = mat

    member this.StepOfVirusInfection() =
            let listOfComputersInfectedInThisStep = new List<Computer>()
            for i in 0 .. listOfAllComputersInNet.Count - 1 do
                if (listOfAllComputersInNet.[i].Infected) then
                    for j in 0 .. listOfAllComputersInNet.Count - 1 do
                        if (matrixOfLink.[i,j] && (listOfAllComputersInNet.[j].Infected = false) && (listOfComputersInfectedInThisStep.Contains(listOfAllComputersInNet.[j]) = false)) then
                            if(rand.Next(1, 100) <= listOfAllComputersInNet.[j].operatingSystem.InfectionProbability) then
                                listOfAllComputersInNet.[j].Infected <- true
                                listOfComputersInfectedInThisStep.Add(listOfAllComputersInNet.[j])

    /// <summary>
    /// print on console network status
    /// </summary>
    member this.PrintStatusInStep() =
           for comp in listOfAllComputersInNet do
               let mutable str = "OS:" + comp.operatingSystem.NameOfOs + " " + "Infection:" + comp.Infected.ToString()
               Console.WriteLine(str)

    /// <summary>
    /// checking all comtures are infected
    /// </summary>
    /// <returns></returns>
    member this.Check() =
           let mutable i = 0;
           for comp in listOfAllComputersInNet do
               if (comp.Infected = false) then
                   i <- i + 1
           (i = 0)

    /// <summary>
    /// start virus infection
    /// </summary>
    member this.VirusInfection() =
           let mutable i = 1;
           Console.WriteLine("Step 0");
           this.PrintStatusInStep();
           while (this.Check() = false) do
               this.StepOfVirusInfection();
               Console.WriteLine("Step " + i.ToString())
               this.PrintStatusInStep()
               System.Threading.Thread.Sleep(800)
               i <- i + 1
           Console.WriteLine("//////////////////////////////////////////////////////////////")
           Console.WriteLine("///////////////////ALL COMPUTERS INFECTED/////////////////////")
           Console.WriteLine("//////////////////////////////////////////////////////////////")