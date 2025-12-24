module CodeWars.FSharp.RomanNumerals

    open System 

    let solution(num: int): String =
            
        let decList =
            let rec createDecList li n =
                if n <= 0 then li
                else
                    createDecList (li @ [ n % 10 ]) (n / 10)

            createDecList [] num
            |> List.rev

        let toRomanNum (index: int) (n: int): String =
            
            let buildRomanNum (r1: string) (r2: string) (r3: string) =
                match n with
                | 9 -> r3 + r1
                | _ when n > 5 -> r2 + (new String(char r3, n - 5))
                | 5 -> r2
                | 4 -> r3 + r2
                | _ when n > 0 -> new String(char r3, n)
                | _ -> ""
                    
            match (decList.Length - index - 1) with
            | 3 -> new String ('M', n)
            | 2 -> buildRomanNum "M" "D" "C"
            | 1 -> buildRomanNum "C" "L" "X"
            | 0 -> buildRomanNum "X" "V" "I"
            | _ -> ""

        decList
        |> Seq.mapi toRomanNum
        |> String.concat ""
