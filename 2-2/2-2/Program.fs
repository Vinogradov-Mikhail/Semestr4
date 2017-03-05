let list = []

let search  list number = 
    let rec help list (index : int) =
        match list with
        |[] -> None
        |_ when List.head list = number -> Some(index)
        |head::tail -> help (List.tail list) (index + 1)
    help list 1

printfn "position of 4 = %A" <| search  list 4