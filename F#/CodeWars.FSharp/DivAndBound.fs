module CodeWars.FSharp.DivAndBound

    let maxMultiple (d: int) (b: int): int =
        [b .. -1 .. 1]
        |> List.find (fun x -> x % d = 0)