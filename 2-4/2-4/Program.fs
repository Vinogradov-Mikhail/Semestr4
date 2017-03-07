let rec mergeSort list = 
    let rec merge left right =
        match left, right with
        | [], [] -> []
        | left, [] -> left
        | [], right -> right
        | leftHead::leftTail, rihgtHead::rightTail -> 
            if leftHead <= rihgtHead then leftHead::merge leftTail right
            else rihgtHead::merge left rightTail  
    match list with
        | [] -> []
        | a::[] -> [a]
        | list ->
            let left, right = List.splitAt(List.length list / 2) list
            merge (mergeSort left) (mergeSort right)

let list = [2; 1; 9; 2; 1]

printfn "sorted list %A" <| mergeSort list