module Test

open Program
open NUnit.Framework
open FsUnit

let test = 
    bulder 3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }

[<Test>]
let ``test from hwproj`` () = 
    test |> should equal 0.048
