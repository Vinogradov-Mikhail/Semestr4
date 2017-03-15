let rec mergeSort list = 
    let rec merge left right result=
        match left, right with
            | [], [] -> List.rev result
            | leftHead::leftTail, [] -> merge leftTail [] (leftHead::result)
            | [], rightHead::rightTail ->  merge rightTail [] (rightHead::result)
            | leftHead::leftTail, rightHead::rightTail -> 
                if leftHead <= rightHead then merge leftTail right (leftHead::result)
                else merge left rightTail (rightHead::result)
    match list with
        | [] -> []
        | a::[] -> [a]
        | list ->
            let left, right = List.splitAt(List.length list / 2) list
            merge (mergeSort left) (mergeSort right) []

let list = List.init 10000 (fun i -> -i)

printfn "sorted list %A" <| mergeSort list