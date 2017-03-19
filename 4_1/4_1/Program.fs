open FsCheck

let evenNumberOne list =
    List.length (List.filter (fun x -> x % 2 = 0) list)

let evenNumberTwo list =
    List.fold (fun acc x -> acc - (abs (x % 2))) (List.length list) list

let evenNumberThree list = 
    (List.length list) - (List.sum (List.map (fun x -> (abs (x % 2))) list))

let reference list =
    let rec help acc listx =
        match listx with
        | [] -> acc
        | head::tail -> 
            if head % 2 = 0 then help (acc + 1) tail
            else help acc tail
    help 0 list

let testingFunctionOne x = 
    (reference x) = (evenNumberOne x)

Check.QuickThrowOnFailure testingFunctionOne

let testingFunctionTwo x =
    (reference x) = (evenNumberTwo x)

Check.QuickThrowOnFailure testingFunctionTwo

let testingFunctionThree x =
    (reference x) = (evenNumberThree x)

Check.QuickThrowOnFailure testingFunctionThree