module TestOfStack

open Program
open NUnit.Framework
open FsUnit

let stack = new Stack<int>();
stack.Push 2
stack.Push 3
stack.Push 4

[<Test>]
let ``is stack size 3?`` =
    stack.Length |> should be True

[<Test>]
let ``in head of stack is 4`` =
    stack.Pop |> should equal 4

[<Test>]
let ``in head of stack is 3`` =
    stack.Pop |> should equal 3