module Test

open NUnit.Framework
open FsUnit
open Program

[<Test>]
let ``test one``() = betaReduction (App(Abs("a", Abs("b", App(Var "a", Var "b"))), Var "b")) |> should equal (Abs("b", App(Var("b"), Var("b"))))

[<Test>]
let ``II =  I``() = betaReduction (App(Abs("x", Var "x"), Abs("x", Var "x"))) |> should equal (Abs("x", Var "x"))

[<Test>]
let `` KI = K*(only beta reduction)``() = betaReduction (App(Abs("x", Abs("y", Var "x")), Abs("x", Var "x"))) |> should equal (Abs("y",Abs("x",Var "x")))

[<Test>]
let ``Right redex``() = betaReduction (App(Var "x", App(Abs("x", Var("x")), Var "x"))) |> should equal (App(Var "x", Var "x"))

[<Test>]
let ``application2``() = betaReduction (App(Abs("s", App(Var "q", Var"s")), Var("y"))) |> should equal (App(Var "q", Var "y"))

[<Test>]
let ``abstractionWithRedexes``() = 
    betaReduction (Abs("x", App(Abs("y", Var("y")), Var("t")))) |> should equal (Abs("x", Var "t"))

[<Test>]
let ``K a b``() = 
    betaReduction (App(App(Abs("x", Abs("y", Var "x")), Var "a"), Var "b")) |> should equal (Var "a")