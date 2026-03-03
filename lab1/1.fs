open System

let rec getlist () = 
    let s = Console.ReadLine()
    if s = null then 
        []
    else 
        s :: getlist()

[<EntryPoint>]
let main argv = 
    printfn "Введите строки (Ctrl+Z для завершения, Enter сохранит пустую строку): "
    let myList = getlist()

    printfn "\nВаш сформированный список: %A" myList
    0
