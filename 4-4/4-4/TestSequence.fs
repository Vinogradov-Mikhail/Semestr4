module TestSequence

open Sequence
open NUnit.Framework
open FsUnit

[<Test>]
let ``contain 5?`` () = 
    Seq.find(fun x -> x = 5) sequence |> should equal 5

[<Test>]
let ``contain 109?`` () = 
    Seq.find(fun x -> x = 109) sequence |> should equal 109

[<Test>]
let ``contain 3571?`` () = 
    Seq.find(fun x -> x = 3571) sequence |> should equal 3571