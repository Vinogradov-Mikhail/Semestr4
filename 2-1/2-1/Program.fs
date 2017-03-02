let numberMultiply x =
    let rec helpMultiply number =
        if number < 10 then number
        else helpMultiply (number / 10) * (number % 10)
    helpMultiply x

let checkOne = numberMultiply 123
printfn "123 = %d" checkOne 

let checkTwo = numberMultiply 3
printfn "3 = %d" checkTwo 

let checkThree = numberMultiply 341111
printfn "341111 = %d" checkThree 
