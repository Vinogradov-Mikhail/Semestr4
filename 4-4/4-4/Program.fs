module Sequence

let isPrimeNumber number =
    let rec help number acc isPrime =
        match acc with
        | 1 -> isPrime
        | _ -> 
            if (number % acc = 0) then help number 1 false
            else  help number (acc - 1) isPrime
    help number (number / 2) true

let sequence = Seq.initInfinite (fun index -> index + 2)
let primeInfiniteSequence =  Seq.filter(fun x -> isPrimeNumber x) sequence

printfn "%A" primeInfiniteSequence