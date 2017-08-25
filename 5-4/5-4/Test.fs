module Test

open NUnit.Framework
open FsUnit
open Program

[<Test>]
let ``test one``() = betareduction (App(Abs("a", Abs("b", App(Var "a", Var "b"))), Var "b")) |> should equal (Abs("b", App(Var("b"), Var("b"))))

[<Test>]
let ``II =  I``() = betareduction (App(Abs("x", Var "x"), Abs("x", Var "x"))) |> should equal (Abs("x", Var "x"))

[<Test>]
let `` KI = K*(only beta reduction)``() = betareduction (App(Abs("x", Abs("y", Var "x")), Abs("x", Var "x"))) |> should equal (Abs("y",Abs("x",Var "x")))