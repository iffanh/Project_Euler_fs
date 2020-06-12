// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let maxNumber = 4000000

let rec fibonacciSum (F1 : int, F2 : int, sum : int) =

    let F3 = F1 + F2
    let sum = sum + F3

    if F3 < maxNumber then
        fibonacciSum (F2, F3, sum)
    else
        (F1, F2, sum)

[<EntryPoint>]
let main argv =

    let F0 = 1
    let F1 = 2
    let sum = F0 + F1

    let _a, _b, finalSum = fibonacciSum (F0, F1, sum)

    Console.WriteLine("This is the result : {0} ", finalSum)

    0 // return an integer exit code