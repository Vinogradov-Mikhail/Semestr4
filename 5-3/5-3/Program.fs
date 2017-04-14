type User =
    {Number : string; Name : string}

let phoneBook =
    let rec interfac phoneBookList =
        let x = System.Console.ReadLine()
        match x with
        |"1" -> 
            printfn "Bye"
        |"2" -> 
            printfn "Write number"
            let number = System.Console.ReadLine()
            printfn "Write name"
            let name = System.Console.ReadLine()
            let user = {Number = number ; Name = name}
            interfac (user :: phoneBookList)
        |"3" ->
             printfn "Write number for search name"
             let name = System.Console.ReadLine()
             if List.exists (fun x -> x.Name = name) phoneBookList then
                 List.iter (fun x -> printfn "%A" <| x.Name + " " + x.Number ) (List.filter (fun x -> x.Name = name) phoneBookList)
             else printfn "I`m sorry"
             interfac phoneBookList
        |"4" -> 
            printfn "Write name for search number"
            let number = System.Console.ReadLine()
            if List.exists (fun x -> x.Number = number) phoneBookList then
                List.iter (fun x -> printfn "%A" <| x.Name + " " + x.Number ) (List.filter (fun x -> x.Number = number) phoneBookList)                
            else printfn "I`m sorry"
            interfac phoneBookList
        |"5" -> 
            List.iter (fun x -> printfn "%A" <| x.Name + " " + x.Number ) phoneBookList
            interfac phoneBookList
        |"6" -> 
            System.IO.File.WriteAllLines("PhoneBook.txt", List.map (fun x -> x.Name + " " + x.Number) phoneBookList)
            printfn "File created"
        |"7" -> 
            printfn ""
            let book =  
                Seq.toList (System.IO.File.ReadLines("PhoneBook.txt"))
            //List.spl
            printfn "Read file succes"
    interfac []