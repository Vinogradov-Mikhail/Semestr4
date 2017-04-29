module Tets

open EvenNumber
open NUnit.Framework
open FsUnit

[<Test>]
let  ``check evenNumberOne `` () = evenNumberOne [1; 2; 3; 2] |> should equal 2

[<Test>]
let  ``check evenNumberTwo`` () = evenNumberTwo [1; 2; 3; 2] |> should equal 2

[<Test>]
let  ``check evenNumberThree `` () = evenNumberThree [1; 2; 3] |> should equal 1
