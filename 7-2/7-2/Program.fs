module Program

type calculate() =
    member this.Bind (n, f) =
        let parseStr = System.Int32.TryParse(n)
        match parseStr with
        | true, x -> f x
        | false, _ -> None

    member this.Return(x) =
        Some(x)   