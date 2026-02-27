open System

// Тип для комплексного числа
type MyComplex = { Re: float; Im: float }

// --- Математические операции ---
let add z1 z2 = { Re = z1.Re + z2.Re; Im = z1.Im + z2.Im }

let sub z1 z2 = { Re = z1.Re - z2.Re; Im = z1.Im - z2.Im }

let mul z1 z2 = 
    { Re = z1.Re * z2.Re - z1.Im * z2.Im
      Im = z1.Re * z2.Im + z1.Im * z2.Re }

let div z1 z2 = 
    let denom = z2.Re ** 2.0 + z2.Im ** 2.0
    if denom = 0.0 then 
        printfn "\n!!! ОШИБКА: Попытка деления на ноль (z2 = 0 + 0i) !!!"
        { Re = 0.0; Im = 0.0 } // Возвращаем ноль вместо вылета
    else
        { Re = (z1.Re * z2.Re + z1.Im * z2.Im) / denom
          Im = (z1.Im * z2.Re - z1.Re * z2.Im) / denom }

// Формула для возведения в степень n
let pow z (n: float) =
    let r = sqrt (z.Re ** 2.0 + z.Im ** 2.0)
    let theta = atan2 z.Im z.Re
    let rn = r ** n
    { Re = rn * cos (n * theta); Im = rn * sin (n * theta) }

// Вывод
let toString z = sprintf "%.2f + %.2fi" z.Re z.Im

[<EntryPoint>]
let main argv =
    printfn "=== Ввод комплексных чисел (a + bi) ==="
    
    // Запрос первого числа
    printf "Введите вещественную часть z1 (a): "
    let re1 = float (Console.ReadLine())
    printf "Введите мнимую часть z1 (b): "
    let im1 = float (Console.ReadLine())
    let z1 = { Re = re1; Im = im1 }

    // Запрос второго числа
    printf "\nВведите вещественную часть z2 (c): "
    let re2 = float (Console.ReadLine())
    printf "Введите мнимую часть z2 (d): "
    let im2 = float (Console.ReadLine())
    let z2 = { Re = re2; Im = im2 }

    // Запрос степени
    printf "\nВ какую степень возвести первое число? "
    let n = float (Console.ReadLine())

    // Вычисления и вывод
    printfn "\n--- Результаты ---"
    printfn "z1 = %s" (toString z1)
    printfn "z2 = %s" (toString z2)
    printfn "------------------------"
    printfn "Сложение:    %s" (toString (add z1 z2))
    printfn "Вычитание:   %s" (toString (sub z1 z2))
    printfn "Умножение:   %s" (toString (mul z1 z2))
    printfn "Деление:     %s" (toString (div z1 z2))
    printfn "z1 в степени %.0f: %s" n (toString (pow z1 n))

    0

    (*
                                                                            тесты(1 варинат)
=== Ввод комплексных чисел (a + bi) ===
Введите вещественную часть z1 (a): 3
Введите мнимую часть z1 (b): 4

Введите вещественную часть z2 (c): 2
Введите мнимую часть z2 (d): 3

В какую степень возвести первое число? 2

--- Результаты ---
z1 = 3.00 + 4.00i
z2 = 2.00 + 3.00i
------------------------
Сложение:    5.00 + 7.00i
Вычитание:   1.00 + 1.00i
Умножение:   -6.00 + 17.00i
Деление:     1.38 + -0.08i
z1 в степени 2: -7.00 + 24.00i

                                                                            тесты (2 вариант)
=== Ввод комплексных чисел (a + bi) ===
Введите вещественную часть z1 (a): 3
Введите мнимую часть z1 (b): 4

Введите вещественную часть z2 (c): 0
Введите мнимую часть z2 (d): 0

В какую степень возвести первое число? 2

--- Результаты ---
z1 = 3.00 + 4.00i
z2 = 0.00 + 0.00i
------------------------
Сложение:    3.00 + 4.00i
Вычитание:   3.00 + 4.00i
Умножение:   0.00 + 0.00i

!!! ОШИБКА: Попытка деления на ноль (z2 = 0 + 0i) !!!
Деление:     0.00 + 0.00i
z1 в степени 2: -7.00 + 24.00i
*)