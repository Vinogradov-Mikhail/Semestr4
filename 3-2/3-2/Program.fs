let searchMaxSumm list =
    let summ = fun (x, y) -> x + y
    let rec helpSearch index indexOfMax maxSumm listx = 
        match listx with
        | [] -> indexOfMax
        | head :: tail -> 
            if maxSumm < summ head then helpSearch (index + 1) index (summ head) tail
            else helpSearch (index + 1) indexOfMax maxSumm tail
    helpSearch  0 0 -1 (List.zip (List.append list [0]) (List.append [0] list)) 

printfn"%A" <| searchMaxSumm [1; 2; 3; 8]