open NUnit.Framework
open FsUnit

type Expression =
    | Number of int
    | Add of Expression * Expression
    | Subtraction of Expression * Expression
    | Multiply of Expression * Expression
    | Division of Expression * Expression

let rec claculate exp =
    match exp with 
    | Number(n) -> n
    | Add(expr1, expr2) -> (claculate expr1) + (claculate expr2)
    | Subtraction(expr1, expr2) -> (claculate expr1) - (claculate expr2);
    | Multiply(expr1, expr2) -> (claculate expr1) * (claculate expr2)
    | Division(expr1, expr2) -> 
        if (claculate expr2) <> 0 then (claculate expr1) / (claculate expr2)
        else failwith "Divisor cannot be zero"
        
[<Test>]
let ``test of tre calculating`` () = 
    claculate <| Add(Number 5, Multiply(Number 4, Number 3)) |> should equal 17
