// Learn more about F# at http://fsharp.net

let p1 =
    [0..999]
    |> List.filter(fun x->x%3=0 || x%5=0)
    |> List.sum

printfn "%i" p1
