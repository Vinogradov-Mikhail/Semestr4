module TestOfSequence

open Program
open NUnit.Framework
open FsUnit

[<Test>]
let ``contain 5?`` () = 
    Seq.find(fun x -> x = 5) sequence |> should equal 5

[<Test>]
let ``lenght of 5 = 5?`` () = 
    Seq.length (Seq.filter(fun x -> x = 5) sequence) |> should equal 5    