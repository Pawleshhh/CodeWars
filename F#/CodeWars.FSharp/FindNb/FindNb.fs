module CodeWars.FSharp.FindNb

    let findNb(m: uint64): int =
        
        let rec find sum (n: uint64): int =
            if sum = m then
                (n - 1UL) |> int32
            elif sum > m then
                -1
            else
                find (sum + (n * n * n)) (n + 1UL)

        find 0UL 1UL