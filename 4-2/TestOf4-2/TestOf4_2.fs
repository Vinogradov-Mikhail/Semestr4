module TestOf4_2

open FsUnit
open NUnit.Framework
open Swensen.Unquote
open 

[<Test>]
let ``FsCheck test 1``() =
    1 |> should equal 1

