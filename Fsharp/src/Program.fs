module WordCounter

open System
open System.IO

type SearchQuery =
    { FilePath: string; SearchWord: string }


let parseArguments (args: string[]) : Result<SearchQuery, string> =
    let doesFileExist (path: string) = File.Exists path

    match args with
    | args when args.Length <> 1 -> Error "Invalid number of arguments"
    | args when not <| doesFileExist args.[0] -> Error "File does not exist"
    | args ->
        Ok
            { FilePath = args.[0]
              SearchWord = Path.GetFileNameWithoutExtension args.[0] }


let getTotalWordAccurences (query: SearchQuery) : int =
    let fileContent = File.ReadLines query.FilePath

    let totalWordHits (words: string array) =
        words
        |> Array.sumBy (fun word ->
            match (word = query.SearchWord) with
            | true -> 1
            | false -> 0)

    fileContent
    |> Seq.sumBy (fun line -> line.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries) |> totalWordHits)


[<EntryPoint>]
let main args =
    match parseArguments args with
    | Ok query ->
        let totalWordHits = getTotalWordAccurences query

        printfn "Word '%s' appears %d times in the file '%s'" query.SearchWord totalWordHits query.FilePath
    | Error message -> printfn "Error: %s" message

    0
