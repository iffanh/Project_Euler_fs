// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

let largestDigit = 9

let smallestFirstDigit = 1
let smallestSecondDigit = 0
let smallestThirdDigit = 1

let isPalindrome (nOriginal : int) =

    let stringNumber = string nOriginal

    // printf "%s \n" stringNumber
    let nReverse = int (String(stringNumber.ToCharArray() |> Array.rev))

    let result = nOriginal - nReverse

    result = 0

let rec secondTripletDecrease (threeDigits : int) (threeDigitsSub : int) (largestPalindrome : int) (product_1 : int) (product_2 : int) =

    let productNumber = threeDigits * threeDigitsSub

    let threeDigitsSub = threeDigitsSub - 1

    if (isPalindrome productNumber) && (productNumber > largestPalindrome) then
        let largestPalindrome = productNumber
        printf "Update largest palindrome : %d \n" largestPalindrome
        let product_1 = threeDigits
        let product_2 = (threeDigitsSub + 1)

        if threeDigitsSub = 1 then (largestPalindrome, threeDigits, threeDigitsSub, product_1, product_2)
        else secondTripletDecrease threeDigits threeDigitsSub largestPalindrome product_1 product_2

    else
        if threeDigitsSub = 1 then (largestPalindrome, threeDigits, threeDigitsSub, product_1, product_2)
        else secondTripletDecrease threeDigits threeDigitsSub largestPalindrome product_1 product_2


let rec firstTripletDecrease (threeDigits : int) (largestPalindrome  : int, firstNumber  : int, secondNumber  : int, product_1 : int, product_2 : int) =

    if threeDigits = 1 then
        (largestPalindrome, firstNumber, secondNumber, product_1, product_2)
    else
        let (largestPalindrome, firstNumber, secondNumber, product_1, product_2) = secondTripletDecrease threeDigits threeDigits largestPalindrome product_1 product_2
        firstTripletDecrease (threeDigits-1) (largestPalindrome, firstNumber, secondNumber, product_1, product_2)



let rec findPalindrome ((a : int), (b : int), (c : int)) =

    let _N = (100*a + 10*b + c)

    let (largestPalindrome, firstNumber, secondNumber, product_1, product_2) = firstTripletDecrease _N (1, _N, _N, 1, 1)

    (largestPalindrome, firstNumber, secondNumber, product_1, product_2)



[<EntryPoint>]
let main argv =

    let a = 9
    let b = 9
    let c = 9

    let (largestPalindrome, firstNumber, secondNumber, product_1, product_2) = findPalindrome (a,b,c)

    printf "Largest palindrom is: %d, product of %d and %d" largestPalindrome product_1 product_2

    0 // return an integer exit code