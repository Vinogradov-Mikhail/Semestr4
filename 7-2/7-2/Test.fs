module Test

open Program
open NUnit.Framework
open FsUnit

let result = 
    calculate () {
         let! x = "1"
         let! y = "2"
         let z = x + y
         return z
     }

let res = calculate () {
        let! x = "1"
        let! y = "Ъ"
        let z = x + y
        return z
    }

[<Test>]
let ``test hwproj one`` () =
    result |> should equal <| Some(3)

[<Test>]
let ``test hwproj two`` () =
    res |> should equal <| None