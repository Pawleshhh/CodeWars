module GrowthOfPopulation

    let nbYear (p0: int) (percent: float) (aug: int) (p: int) =
    
        let rec calcYear (p0: int) (percent: float) (aug: int) (p: int) (y: int) =
            if p0 >= p then
                y
            else
                let per = percent / 100.0
                let pFl = p0 |> float
                let p0n = p0 + ((pFl * per) |> int) + aug
                calcYear p0n percent aug p (y + 1)

        calcYear p0 percent aug p 0