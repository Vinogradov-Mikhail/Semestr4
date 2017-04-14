module Program

type Stack<'a>() =
    let mutable stack = []

    member this.IsEmpty = (stack = [])
    
    member this.Push x = stack <- (x :: stack)

    member this.Pop = 
        match stack with
        |[] -> failwith "Oops, stack is empty"
        |(head :: tail) -> 
            stack <- tail
            head

    member this.Length = stack.Length

let stack = new Stack<int>();
stack.Push 5
stack.Push 0
stack.Push 10
stack.Push 3

printfn "Верхний элемент %d удален" stack.Pop