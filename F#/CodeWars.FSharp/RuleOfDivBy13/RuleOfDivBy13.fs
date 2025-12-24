module CodeWars.FSharp.RuleOfDivBy13

    let sequence = [ 1; 10; 9; 12; 3; 4 ]
    
    let rec retrieveDecimals l n =
        if n <= 0 then
            l
        else
            retrieveDecimals (n % 10 :: l) (n / 10)

    let rec thirt m =
         
        retrieveDecimals [] m
        |> List.rev
        |> List.chunkBySize 6
        |> List.map (fun i ->
            (sequence.[..(i.Length - 1)], i)
            ||> List.map2 (fun x y -> x * y))
        |> List.collect id
        |> List.sum
        |> fun sum -> if sum = m then m else thirt sum
