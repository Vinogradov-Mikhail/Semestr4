module Program

type Term =
    | Var of string
    | Abs of string * Term
    | App of Term * Term

let alphabet = ["a"; "b"; "c"; "d"; "e"; "f"; "g"; "k"; "l"; "m"; "w"; "q"; "s"; "l"]

let rec checkCollision x k =
    match x with
    | Var(s) when (s = k) -> true
    | Abs(s, p) when (s = k) || checkCollision p k -> true  
    | App(s, p) when (checkCollision s k) || (checkCollision p k) -> true      
    | _ -> false

let getLetter k = List.head (List.filter (fun x -> not (checkCollision k x)) alphabet)   

let rename a b x = 
    if (a = b) then 
        getLetter x
    else a

let rec alphaReduction check x y =
    match x with
    | Var(o) -> Var(rename o check y)
    | Abs(s, p) -> Abs(rename s check y, alphaReduction check p y)
    | App(s, p) -> App(alphaReduction check s y, alphaReduction check p y)

let rec betaAbs check k y =
   match k with
   | Var(t) when (t = check) -> y
   | Var(t) -> Var(t)
   | Abs(m, n) -> Abs(m, betaAbs check n y)
   | App(m, n) -> App(betaAbs check m y, betaAbs check n y)

let rec betaReduction x =     
    match x with   
    | Var(t) -> Var(t) 
    | Abs(t, s) -> 
        match s with
            | App(m, n) -> Abs(t, betaReduction (App(betaReduction m, betaReduction n)))
            | Abs(m, n) -> Abs(t, betaReduction s)
            | _ -> Abs(t, s)
    | App(Var(y), s) -> 
        match s with
        | App(m, n) -> App(Var(y), betaReduction (App(betaReduction m, betaReduction n)))
        | _ -> App(Var(y), s)
    | App(Abs(t, u), y) -> 
        match y with
        |Var(o) when (checkCollision x o) -> betaReduction (betaAbs (rename t o x) (alphaReduction o u x) y)     
        | _ ->  betaReduction (betaAbs t u y)
    | App(s, y) -> betaReduction (App(betaReduction s, betaReduction y))