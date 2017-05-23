module Main

open System.Collections.Generic
open Program

[<EntryPoint>]
let main argv = 
    let mac = { NameOfOs = "Mac"; InfectionProbability = 10 }
    let windows = { NameOfOs = "Windows"; InfectionProbability = 80 }
    let linux = { NameOfOs = "Linux"; InfectionProbability = 40 }
    let mat : bool[,] = Array2D.zeroCreate 3 3
    let createMat (mat : bool[,]) = 
        mat.[0,0] <- false;
        mat.[0,1] <- true;
        mat.[0,2] <- true;
        mat.[1,0] <- true;
        mat.[1,1] <- false;
        mat.[1,2] <- false;
        mat.[2,0] <- true;
        mat.[2,1] <- false;
        mat.[2,2] <- false;
        mat
    let computers = List<Computer>()
    let addComputers = 
        computers.Add({ operatingSystem = windows;  Infected = false })
        computers.Add({ operatingSystem = linux;  Infected = false })
        computers.Add({ operatingSystem = mac;  Infected = true })
        computers
        
    let network = new LocalNetwork(addComputers, createMat mat)
    network.VirusInfection()
    0 // возвращение целочисленного кода выхода