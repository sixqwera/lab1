open System


let rec getlist () = 
    let s = Console.ReadLine()
    if s  = "" then []
    else s :: getlist()


[<EntryPoint>]
let main argv = 
    printfn "Введите строки (пустая строка для завершения): "
    let myList = getlist()

    printfn "\nВаш сформированный список: %A" myList

    0

(*
тесты (1 вариант)
Введите строки (пустая строка для завершения):
111
222
333


Ваш сформированный список: ["111"; "222"; "333"]
*)