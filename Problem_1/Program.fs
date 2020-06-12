open System

let maxNumber = 1000

let rec checkDivisions sum iter =

    let sum =
        if ( iter%3 = 0 || iter%5 = 0 ) then
            sum + iter
        else
            sum

    if iter = maxNumber - 1 then sum
    else checkDivisions sum (iter + 1)


[<EntryPoint>]
let main argv =

    let finalSum = checkDivisions 0 1

    Console.WriteLine("This is the result : {0}", finalSum)

    0
