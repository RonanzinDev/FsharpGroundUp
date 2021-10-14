open System
open System.IO

type Student = {
    Name : string
    Id : string
    MeanScore: float
    MinScore: float
    MaxScore: float
}

module Student =
    let fromString(s : string) = 
        let elements = row.Split('\t')
        let name = elements.[0]
        let id = elements.[1]

        let scores =
            elements |> Array.skip 2 |> Array.map float // Convertando tudo para float

        let meanScore = scores |> Array.average // tirando a media
        let minScore = scores |> Array.min
        let maxScore = scores |> Array.max
   
let printMeamScore (row: string) =
    printfn "%s\t%s\t%0.1f" name id meanScore minScore maxScore
    


let sumarize filepath =
    let rows = File.ReadAllLines filepath
    let studentCount = (rows |> Array.length) - 1 // pq tem o header que tem o name, etc..
    printf "\nStudent Count %i\n" studentCount

    rows
    |> Array.skip 1 // pulando o header
    |> Array.iter printMeamScore

[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filepath = argv.[0]

        if File.Exists filepath then
            printf "Processing %s ..." filepath
            sumarize filepath
            0
        else
            printf "File not found: %s" filepath
            2
    else
        printf "Please specify a file"
        1
