module CodeWars.FSharp.RomanNumerals

    open System 

        let solution(num: int): String =
            
            let numStr = string num
            let romanChars =
                Map [
                    "M", 1000
                    "D", 500
                    "C", 100
                    "L", 50
                    "X", 10
                    "V", 5
                    "I", 1
                ]

            let buildNumber (x: string)

            let toRomanNum (index: int) (c: char): String =

                let ci = c |> int

                if ci = 0 then ""
                else
                    match (numStr.Length - index - 1) with
                    | 3 -> string (romanChars["M"] * 3)
                    | 2 -> get3rdDecimal ()
                    | _ -> ""

            numStr
            |> Seq.toArray
            |> Array.mapi toRomanNum
            |> String.concat ""
