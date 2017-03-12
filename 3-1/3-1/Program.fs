let rec areElementsDifferentInList list =
    match list with
        | [] -> true
        | head :: tail ->
            if List.exists (fun n -> n = head) tail then false
            else areElementsDifferentInList tail

let ls = [1; 2; 2; 4]

printfn"elements is different? - %A" <| areElementsDifferentInList ls