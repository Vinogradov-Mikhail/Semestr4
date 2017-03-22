let check x =
    let rec help y n acc=
        match n with
        | 1 -> acc
        | _ -> 
            if (y % n = 0) then help y 1 false
            else  help y (n - 1) acc
    help x (x / 2) true

let square = Seq.initInfinite (fun index -> index + 2)
let primeSquare =  Seq.filter(fun x -> check x) square
printfn "%A" primeSquare