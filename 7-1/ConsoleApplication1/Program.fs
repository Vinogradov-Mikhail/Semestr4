module Program

type bulder(x : int) =
    member this.Bind (n : float, f : float -> float) =
        f (System.Math.Round(n, x))

    member this.Return (n : float) =
        System.Math.Round(n, x)