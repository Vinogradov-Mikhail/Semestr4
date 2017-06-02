module Program

open System
open System.Collections
open System.Collections.Generic

//tree struct
type Tree<'a> = 
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Value of 'a option

//binary tree enumerator
type Enumerator<'a when 'a : comparison>(binTree : Tree<'a>) =
    let rec treeList binTree =
       match binTree with
        | Value(None) -> []
        | Value(Some(value)) -> [value]
        | Tree(value, left, right) ->  value :: treeList left @ treeList right
    let helpList = treeList binTree
    let mutable list = (List.head helpList) :: helpList

    interface IEnumerator<'a> with
        member this.MoveNext() = 
            match list with
            | (head :: tail) -> 
                list <- tail
                not list.IsEmpty
            | [] -> false

        member this.Reset() = 
            list <- treeList binTree

        member this.Current = List.head list

        member this.get_Current() =  (this :> IEnumerator<'a>).Current :> obj 

        member this.Dispose () = ()

//type for binary tree
type BinaryTree<'a when 'a: comparison>() = 
    let mutable binTree = Value(None)

    //add value in binarytree
    member this.Add(x: 'a) = 
        let rec ad binTree x = 
            match binTree with
            | Value(None) -> Value(Some(x))
            | Value(Some(value)) -> 
                if x < value then 
                    Tree(value, Value(Some(x)), Value(None))
                else Tree(value, Value(None), Value(Some(x)))
            | Tree(value, left, right) -> 
                if x < value then 
                    Tree(value, ad left x, right)
                else Tree(value, left, ad right x)           
        binTree <- ad binTree x

    //delete value from binarytree
    member this.Delete(x: 'a) =        
        let rec del binTree x = 
            match binTree with
            | Value(None) -> Value(None)
            | Value(Some(value)) -> 
                if value = x then 
                    Value(None)
                else binTree
            | Tree(value, left, right) when x < value -> Tree(value, del left x, right)
            | Tree(value, left, right) when x > value -> Tree(value, left, del right x)
            | Tree(value, left, right) -> 
                match right with
                | Value(None) -> Value(None)        
                | _ ->
                    match left with
                    | Value(None) -> right 
                    | _ ->
                       let rec mostValue binTree = // function for find max value in left tree for input this in root
                            match binTree with
                            | Value(None) -> Value(None) 
                            | Value(value) -> Value(value)
                            | Tree(value, left, right) ->
                                match right with
                                | Value(None) -> binTree
                                | _ -> mostValue right
                       match (mostValue left) with
                       | Value(Some(value)) -> Tree(value, del left value, right)
                       | _ -> Value(None)
        binTree <- del binTree x

    member this.Exist(x: 'a) =
        let rec ex binTree x = 
            match binTree with
            | Value(None) -> false
            | Value(Some(value)) -> 
                x = value
            | Tree(value, left, right) -> 
                if x < value then 
                    ex left x
                else ex right x
        ex binTree x        

    interface IEnumerable<'a> with
       member t.GetEnumerator() = new Enumerator<'a>(binTree) :> IEnumerator<'a>
       member t.GetEnumerator() = (t :> IEnumerable<'a>).GetEnumerator() :> IEnumerator

