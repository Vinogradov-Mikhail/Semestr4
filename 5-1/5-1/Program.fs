module Program

let checkBrackets (str : string) =
    let list = List.ofArray (str.ToCharArray())
    let isBreket x =
        (x = ')') || (x = '}') || (x = ']')
    let reverseBreket x =
        match x with
        |')' -> '('
        |']' -> '['
        |'}' -> '{'
        | _ -> '_'
    let rec help listx openBrackets isCorrect=
        match listx with 
        | [] -> 
            if (List.isEmpty openBrackets) then isCorrect
            else false  
        | head :: tail when (head = '(') || (head = '{') || (head = '[') -> 
            help tail (head :: openBrackets) isCorrect
        | head :: tail when (List.isEmpty openBrackets) -> 
                if (isBreket head) then
                    help [] [] false
                else help [] [] true
        | head :: tail when ((reverseBreket head) = (List.head openBrackets)) -> help tail (List.tail openBrackets) true
        | head :: tail -> help tail openBrackets isCorrect
    help list [] true