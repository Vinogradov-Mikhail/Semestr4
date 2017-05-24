module Test

open Program
open NUnit.Framework
open FsUnit

[<Test>]
let ``check correcting`` () =
    func 2 [1;2;3] |> should equal <| pointFree 2 [1;2;3]