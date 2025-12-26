module CodeWars.FSharp.TrailingZerosOfN

    let zeros n =
        let allNums = [2 .. n]
        allNums
        |> List.mapi (fun i x ->
            [x + 1 .. n]
            |> List.tryFind (fun y ->
                if x * y % 10 = 0 then
                    true))