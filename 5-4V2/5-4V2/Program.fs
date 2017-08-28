module Program

type Term =
    | Var of string
    | Abs of string * Term
    | App of Term * Term

let rec betaReduction x = 
    let rec betaApp c y = 
        match c with
        | App(s, p) -> App(betaApp s y, p)
        | Abs(s, p) -> 
                let rec betaAbs check k =
                    match k with
                    | Var(t) when t = check -> y
                    | Var(t) -> Var(t)
                    | Abs(m, n) -> Abs(m, betaAbs check n)
                    | App(m, n) -> App(betaAbs check m, betaAbs check n)
                match p with
                | Var(o) when o = s -> y
                | Var(o) -> Var(o)
                | Abs(q, w) -> Abs(q, betaAbs s w)
                | App(q, w) -> betaApp q y
        | Var(_) -> App(c, y)
    match x with   
    | Var(t) -> Var(t) 
    | Abs(t, s) -> Abs(t, s)
    | App(Var(y), s) -> 
        match s with
        | App(m, n) -> App(Var(y), betaReduction (betaApp m n))
        | _ -> App(Var(y), s)
    | App(s, y) -> betaReduction (betaApp s y)