// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let number = 100

// let rec smallestDivisor (a : int) (b : int) =

let rec findLargestDivisor (d : int) (N : int) =

    let remainder = N%d

    if remainder = 0 then
        d
    else
        findLargestDivisor (d-1) N

let rec largestPrime (N : int) =

    let _n = int (ceil (sqrt (float N)))

    // let divisor = _n

    let lDiv = findLargestDivisor _n N

    // let N = N/lDiv

    0



[<EntryPoint>]
let main argv =

    let result = largestPrime number

    printf "This is the result : %d" result

    0