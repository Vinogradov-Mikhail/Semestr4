open System

type User =
    {Number : string; Name : string}

let rec fromStringToUser book list =
    match list with
    |[] -> book
    |(head : string) :: tail -> 
        let contact = Seq.toList (head.Split ' ')
        let number = List.head contact 
        let contactTail = List.tail contact
        let name = List.head contactTail
        let user = {Number = number ; Name = name}
        fromStringToUser (user :: book) tail

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
            interfac phoneBookList
        |"7" -> 
            let book = Seq.toList (System.IO.File.ReadLines("PhoneBook.txt"))
            let newBook = fromStringToUser phoneBookList book
            printfn "Read file succes" 
            interfac newBook
        |_ -> 
            printfn "Try another" 
            interfac phoneBookList
    interfac []