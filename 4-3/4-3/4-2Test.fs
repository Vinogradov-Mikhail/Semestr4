module _4_2Test

open TreeCalc
open NUnit.Framework
open FsUnit

[<Test>]
let ``calculate 5 + 4 * 3`` () = 
    claculate <| Add(Number 5, Multiply(Number 4, Number 3)) |> should equal 17

[<Test>]
let ``calculate 10 /(2*1)`` () = 
    claculate <| Division(Number 10, Multiply(Number 2, Number 1)) |> should equal 5

[<Test>]
let ``calculate 1+`` () = 
    claculate <| Number(1) |> should equal 1