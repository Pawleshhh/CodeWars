module CodeWars.FSharp.DisemvowelTrolls

    let disemvowel (s: string): string =
      let vowels = ['a'; 'A'; 'e'; 'E'; 'i'; 'I'; 'o'; 'O'; 'u'; 'U']

      s
      |> Seq.toList
      |> List.filter (fun c -> List.contains c vowels |> not)
      |> List.toArray
      |> System.String