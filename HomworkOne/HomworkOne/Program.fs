//task 1
let rec factorial x =
    if x = 1 then 1 
    else x * factorial (x - 1)

let value = factorial 3
printfn "3! = %d" value

//task 2
let fibonacci x =
    let rec fibIter a b count =
        if count = 0 then b
        else fibIter (a + b) a (count - 1)
    fibIter 1 0 x

let thirdFibonacci = fibonacci 3
printfn "fibonacci №3 = %d"  thirdFibonacci        

//task 3
let reverse listx =
    let rec reverseList listx listn=
        match listx with
        | head :: tail -> reverseList tail (head :: listn)
        | [] -> listn
    reverseList listx []

let revList = [1..5]   
printfn "reverse list = %A" <| reverse revList

//task 4
let listOfdegree x y = 
    List.map (fun n -> pown 2 n) <| [x..x + y]

printfn "%A" <| listOfdegree 5 2