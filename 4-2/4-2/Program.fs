open NUnit.Framework
open FsUnit

type Tree<'a> =
    |Tree of 'a * Tree<'a> * Tree<'a>
    |Tip of 'a

let rec mapTree func tree =
    match tree with
    |Tree(x, l, r) -> Tree(func x, mapTree func l, mapTree func r)
    |Tip(x) -> Tip(func x)

[<Test>]
let ``Adding 1 to all nodes`` () =
    mapTree (fun x -> x % 2) <| Tree (5, Tree (4, Tip 8, Tip 3), Tip 1) |> should equal <| Tree (1, Tree (0, Tip 0, Tip 1), Tip 1)    