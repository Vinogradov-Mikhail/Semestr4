let checkPolidrom (str : string) =
    let myArray = str.ToCharArray()
    let list = myArray |> Array.toList
    let reverse listx =
        let rec reverseList listx listn=
            match listx with
            | head :: tail -> reverseList tail (head :: listn)
            | [] -> listn
        reverseList listx []
    reverse list = list

let polid = "adada"  
printfn "string is polindrom = %A" <| checkPolidrom polid