module CodeWars.FSharp.ToCamelCase

    let toCamelCase (text: string) =
        let isSeparator c = c = '-' || c = '_'

        let toUpperCase (c: char) = c |> System.Char.ToUpperInvariant

        text
        |> Seq.fold (fun s c ->
            match s with
            | (l, _) when isSeparator c -> (l @ [], true)
            | (l, b) when b -> (l @ [toUpperCase c], false)
            | (l, _) -> (l @ [c], false))
            (List.Empty, false)
        |> fst
        |> List.toArray
        |> System.String