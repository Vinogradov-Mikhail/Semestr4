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
let ``mod 2 to all tree`` () =
    mapTree (fun x -> x % 2) <| Tree (5, Tree (4, Tip 8, Tip 3), Tip 1) |> should equal <| Tree (1, Tree (0, Tip 0, Tip 1), Tip 1)    

[<Test>]
let ``divison 2`` () =
    mapTree (fun x -> x / 2) <| Tree (6, Tree (4, Tip 8, Tip 4), Tip 4) |> should equal <| Tree (3, Tree (2, Tip 4, Tip 2), Tip 2)    
