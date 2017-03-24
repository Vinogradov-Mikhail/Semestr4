open NUnit.Framework
open FsUnit

let evenNumberOne list =
    List.length (List.filter (fun x -> x % 2 = 0) list)

let evenNumberTwo list =
    List.fold (fun acc x -> acc - (abs (x % 2))) (List.length list) list

let evenNumberThree list = 
    (List.length list) - (List.sum (List.map (fun x -> (abs (x % 2))) list))

[<Test>]
let  ``check evenNumberOne `` () = evenNumberOne [1; 2; 3; 2] |> should equal 2

[<Test>]
let  ``check evenNumberTwo`` () = evenNumberTwo [1; 2; 3; 2] |> should equal 2

[<Test>]
let  ``check evenNumberThree `` () = evenNumberThree [1; 2; 3] |> should equal 1