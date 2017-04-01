module Program

let checkBrackets (str : string) =
    let list = List.ofArray (str.ToCharArray())
    let rec help listx openBrackets isCorrect=
        match listx with 
        | [] -> 
            if (List.isEmpty openBrackets) then isCorrect
            else false  
        | head :: tail when (head = '(') || (head = '{') || (head = '[') -> 
            help tail (head :: openBrackets) isCorrect
        | head :: tail when (List.isEmpty openBrackets) && (List.length listx = 1) ->  help [] [] false
        | head :: tail when (head = ')') && ((List.head openBrackets) = '(') -> help tail (List.tail openBrackets) true
        | head :: tail when (head = ')') -> help [] [] false
        | head :: tail when (head = ']') && ((List.head openBrackets) = '[') -> help tail (List.tail openBrackets) true
        | head :: tail when (head = ']') -> help [] [] false
        | head :: tail when (head = '}') && ((List.head openBrackets) = '{') -> help tail (List.tail openBrackets) true
        | head :: tail when (head = '}') -> help [] [] false
        | head :: tail -> help tail openBrackets isCorrect
    help list [] true