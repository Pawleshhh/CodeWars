module DisemvowelTrollsTest

    open NUnit
    open NUnit.Framework
    open CodeWars.FSharp.DisemvowelTrolls

    [<TestFixture>]
    type public FixedTests () =
        
        [<TestCase("This website is for losers LOL!", 
                   "Ths wbst s fr lsrs LL!",
                   Description="\"This website is...\"")>]
        [<TestCase("No offense but,\nYour writing is among the worst I've ever read",
                   "N ffns bt,\nYr wrtng s mng th wrst 'v vr rd",
                   Description="\"No offense...\"")>]
        [<TestCase("What are you, a communist?",
                   "Wht r y,  cmmnst?",
                   Description="\"What are you...\"")>]
        member public this.FixedTests (input:string) (expected:string): unit  =
            Assert.That(expected, Is.EqualTo(disemvowel input), $"Incorrect answer for input=\"{input}\"")

    [<TestFixture>]
    type public RandomTests () =
        [<Test>]
        member public this.RandomTests (): unit  =
          let rng = System.Random()
          let letters = "bcdfghjklmnpqrsrvwxyzBCDFGHJKLMNPQRSTVWXYZ'aeiouAEIOU"
          let punc = "?!,;."

          let genChar  (alphabet: string): char = alphabet.[rng.Next(alphabet.Length)]
          let genChars alphabet n = [1..n] |> List.map (fun _ -> genChar alphabet)
          let genWordChars n = genChars letters n
          
          let disemvowelRef: string->string =
            let isNotVowel l = Seq.contains l "aeiouAEIOU" |> not  
            Seq.filter isNotVowel >> Seq.map string >> String.concat ""

          let genWord () =
            let wordLen = rng.Next(1, 10)
            let word = genWordChars wordLen |> Seq.map string |> String.concat ""
            word
          
          let addRandomPunct word =
            match rng.Next(3) with
            | 0 -> word + (genChar punc |> string)
            | _ -> word

          let genSentence () =
            let sentence =
                Seq.init (rng.Next(1, 8)) (fun _ -> genWord () )
                |> Seq.map addRandomPunct
                |> String.concat " " 
            (disemvowelRef sentence, sentence)
            
          let cases = Seq.init 100 (fun _ -> genSentence())
          cases |> Seq.iter (fun (expected, input) ->
            Assert.That(expected, Is.EqualTo(disemvowel input), $"Incorrect answer for input=\"{input}\"")
          )