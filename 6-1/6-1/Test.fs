module Test

open Program
open NUnit.Framework
open FsUnit

[<Test>]
let ``test with 3 computers``() = 
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
    let addComputers = [{ operatingSystem = windows;  Infected = false }; 
                        { operatingSystem = linux;  Infected = false }
                        { operatingSystem = mac;  Infected = true }]
    let network = new LocalNetwork(addComputers, createMat mat)
    network.VirusInfection()
