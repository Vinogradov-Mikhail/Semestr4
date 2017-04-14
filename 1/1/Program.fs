module Program

let sequence = Seq.initInfinite (fun x -> x + 1)
let testSequence = Seq.collect (fun x -> Seq.init x (fun index -> x)) sequence 