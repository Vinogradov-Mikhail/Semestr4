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
        printfn "1 - exit"
        printfn "2 - add contact"
        printfn "3 - search contact from name"
        printfn "4 - search contact from number"
        printfn "5 - print"
        printfn "6 - create file"
        printfn "7 - read from file"
        let x = System.Console.ReadLine()
        match x with
        |"1" -> 
            printfn "Bye"
        |"2" -> 
            printfn "Write number"
            let number = Console.ReadLine()
            printfn "Write name"
            let name = Console.ReadLine()
            let user = {Number = number ; Name = name}
            interfac (user :: phoneBookList)
        |"4" ->
             printfn "Write number for search name"
             let name = Console.ReadLine()
             if List.exists (fun x -> x.Name = name) phoneBookList then
                 List.iter (fun x -> printfn "%A" <| x.Name + " " + x.Number ) (List.filter (fun x -> x.Name = name) phoneBookList)
             else printfn "I`m sorry"
             interfac phoneBookList
        |"3" -> 
            printfn "Write name for search number"
            let number = Console.ReadLine()
            if List.exists (fun x -> x.Number = number) phoneBookList then
                List.iter (fun x -> printfn "%A" <| x.Name + " " + x.Number ) (List.filter (fun x -> x.Number = number) phoneBookList)                
            else printfn "I`m sorry"
            interfac phoneBookList
        |"5" -> 
            List.iter (fun x -> printfn "%A" <| x.Name + " " + x.Number ) phoneBookList
            interfac phoneBookList
        |"6" -> 
            IO.File.WriteAllLines("PhoneBook.txt", List.map (fun x -> x.Name + " " + x.Number) phoneBookList)
            printfn "File created"
            interfac phoneBookList
        |"7" -> 
            if (IO.File.Exists("PhoneBook.txt")) then
                let book = Seq.toList (IO.File.ReadLines("PhoneBook.txt"))
                let newBook = fromStringToUser phoneBookList book
                printfn "Read file succes" 
                interfac newBook
            else 
                printfn "File not found" 
                interfac phoneBookList
        |_ -> 
            printfn "Try another" 
            interfac phoneBookList
    interfac []