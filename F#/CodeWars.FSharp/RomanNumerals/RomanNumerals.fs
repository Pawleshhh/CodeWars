module CodeWars.FSharp.RomanNumerals

    open System 

        let solution(num: int): String =
            
            let numStr = string num

            let toRomanNum (index: int) (c: char): String =
            
                let ci = c |> int

                if ci = 0 then ""
                else
                    let get4thDecimal () =
                        new String('M', ci)

                    let get3rdDecimal () =
                        ""
                    
                    let getNumPlace = numStr.Length - index - 1
                    match index with
                    | 3 -> get4thDecimal ()
                    | 2 -> get3rdDecimal ()
                    | _ -> ""

            numStr
            |> Seq.toArray
            |> Array.mapi toRomanNum
            |> String
