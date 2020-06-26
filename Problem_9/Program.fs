// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System


let rec getMandN divisorList (N : int) =
    match divisorList with
    | head :: tail ->
        if head < N/head then
            let m = N/(2*head)
            let n = head - m

            if m*(m+n) = N/2 && m > 0 && n > 0 then
                printfn "1. Get m and n: \n %A %A" n m
                m, n
            else getMandN tail N

        else
            let m = head
            let n = N/(2*head) - m

            if m*(m+n) = N/2 && m > 0 && n > 0 then
                printfn "2. Get m and n: \n %A %A" n m
                m, n
            else getMandN tail N
    | [] ->
        0, 0


let removeNonDivisor (N : int) newList oldList =

    let rec wholeLoop newList oldList =
        match oldList with
        | head :: tail ->
            if N % head = 0 then
                wholeLoop (List.append newList [head]) tail
            else
                wholeLoop (List.append newList []) tail
        | [] -> newList



    let divisorList = wholeLoop newList oldList

    printfn "This is the list of the divisor: \n %A" divisorList

    let m, n = getMandN divisorList N

    let a = m*m - n*n
    let b = 2*m*n
    let c = m*m + n*n

    printfn "The pythagorean triplets are: \n %A" (a,b,c)

    a*b*c


let getDivisor (N : int) =

    removeNonDivisor N [] [1 .. N]

[<EntryPoint>]
let main argv =
    let pythagoreanSum = 1000 // Call the function

    printfn "The product of the triplets is: \n %d" (getDivisor pythagoreanSum)
    0 // return an integer exit code