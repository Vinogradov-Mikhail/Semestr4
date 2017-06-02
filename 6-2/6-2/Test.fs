module Test

open Program
open NUnit.Framework
open FsUnit

[<Test>]
let ``simple add  test``() =
    let tree = new BinaryTree<int>()
    tree.Add(4)
    tree.Add(5)
    tree.Add(1)
    tree.Add(2)
    tree.Exist(5) |> should equal true
    tree.Exist(2) |> should equal true

[<Test>]
let ``simple delete test``() =
    let tree = new BinaryTree<int>()
    tree.Add(4)
    tree.Add(5)
    tree.Add(2)
    tree.Delete(5)
    tree.Exist(5) |> should equal false
    tree.Exist(2) |> should equal true

[<Test>]
let ``simple iterator test``() =
    let tree = new BinaryTree<int>()
    tree.Add(5)
    tree.Add(4)
    tree.Add(2)
    tree.Add(3)
    let mutable i = 0
    let mutable list = []
    for x in tree do
        list <- (x :: list)
        i <- i + 1
    i |> should equal 4
    list |> should equal [3;2;4;5]

        
