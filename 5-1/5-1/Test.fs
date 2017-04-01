module Test

open Program
open NUnit.Framework
open FsUnit

[<Test>]
let ``check (ammama)()`` =
    checkBrackets "(ammama)()" |> should be True

[<Test>]
let ``check (ammama)({)}`` =
    checkBrackets "(ammama)({)}" |> should be False

[<Test>]
let ``check ({[]})()`` =
    checkBrackets "({[]})()" |> should be True