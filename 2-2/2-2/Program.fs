let list = [1; 2; 3; 4; 5]

let search  list number = 
    let rec help list index =
            if (List.length list > 0) then
                if (List.head list = number) then index
                    else help (List.tail list) (index + 1)
            else -228
    help list 1

printfn "position of 4 = %A" <| search  list 4