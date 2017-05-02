let drawSquare count =
    let rec square n =
        let rec lineWithSpace index (str : string) =
            match index with
            |2 -> printfn "%A" <| "*" + str + "*"
            |_ -> lineWithSpace (index - 1) (str.Insert(0," "))
        let rec lineWithoutSpace index (str : string) =
            match index with
            |1 -> printfn "%A" <| str + "*"
            |_ -> lineWithoutSpace (index - 1) (str.Insert(0,"*"))
        match n with
        |1 -> lineWithoutSpace count ""
        |_ when n = count -> 
            lineWithoutSpace count ""
            square (n - 1)
        |_ -> 
            lineWithSpace count ""
            square (n - 1)
    square count

let draw = drawSquare 5