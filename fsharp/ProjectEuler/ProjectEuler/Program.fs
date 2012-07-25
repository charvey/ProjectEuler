// Learn more about F# at http://fsharp.net

let p1 n = function
    let rec p1_r n
        match n with
        | 1000 -> 0
        | i when i%5=0 || i%3=0 -> n+p1(n+1)
        | n -> p1 (n+1)
        | 5
    (p1_r 0)



printfn "%i" (p1 0)