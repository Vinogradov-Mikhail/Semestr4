module EvenNumber

let evenNumberOne list =
    List.length (List.filter (fun x -> x % 2 = 0) list)

let evenNumberTwo list =
    List.fold (fun acc x -> acc - (abs (x % 2))) (List.length list) list

let evenNumberThree list = 
    (List.length list) - (List.sum (List.map (fun x -> (abs (x % 2))) list))