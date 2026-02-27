open System

let rec readStrings () = 
    let input = Console.ReadLine()
    if String.IsNullOrEmpty(input) then
        []
    else
        input :: readStrings()


let rec sumLength (list: string list) = 
    match list with

    | [] -> 0
    | head :: tail -> head.Length + sumLength tail

[<EntryPoint>]
let main argv = 
    printfn "Введите строки: "

    let mylist = readStrings()

    let total = sumLength mylist

    printfn "\nВы ввели список: %A" mylist
    printfn "суммарная длина всех строк: %d" total
    0

 (*
                                                                               тесты(вариант 1)
Введите строки:
1
231
231
231
231
3


Вы ввели список: ["1"; "231"; "231"; "231"; "231"; "3"]
суммарная длина всех строк: 14
 *)