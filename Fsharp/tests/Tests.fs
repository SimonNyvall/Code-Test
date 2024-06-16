module Tests

open System
open System.IO
open Xunit
open WordCounter

[<Fact>]
let ``parseArguments takes in incurect amout of arguments expect error message`` () =
    let result = parseArguments [| "file.txt"; "file2.txt" |]

    let expected = Error "Invalid number of arguments"

    Assert.Equal(expected, result)


[<Fact>]
let ``parseArguments takes in non existing file path expect error message`` () =
    let result = parseArguments [| "file.txt" |]

    let expected = Error "File does not exist"

    Assert.Equal(expected, result)


[<Fact>]
let ``parseArguments takes in existing file expect OK`` () =
    let arrange =
        let path = Path.Combine(__SOURCE_DIRECTORY__, "file.txt")
        File.WriteAllText(path, "file file file")

    let result = parseArguments [| Path.Combine(__SOURCE_DIRECTORY__, "file.txt") |]

    let expected =
        Ok
            { FilePath = Path.Combine(__SOURCE_DIRECTORY__, "file.txt")
              SearchWord = "file" }

    Assert.Equal(expected, result)

    // Cleanup
    File.Delete(Path.Combine(__SOURCE_DIRECTORY__, "file.txt"))


[<Fact>]
let ``getTotalWordAccurences takes SearchQuery expect 0`` () =
    let arrange =
        let path = Path.Combine(__SOURCE_DIRECTORY__, "file.txt")
        File.WriteAllText(path, "file file file")

    let query =
        { FilePath = Path.Combine(__SOURCE_DIRECTORY__, "file.txt")
          SearchWord = "file2" }

    let result = getTotalWordAccurences query

    let expected = 0

    Assert.Equal(expected, result)

    // Cleanup
    File.Delete(Path.Combine(__SOURCE_DIRECTORY__, "file.txt"))


[<Fact>]
let ``getTotalWordAccurences takes SearchQuery expect 3`` () =
    let arrange =
        let path = Path.Combine(__SOURCE_DIRECTORY__, "file.txt")
        File.WriteAllText(path, "file file file")

    let query =
        { FilePath = Path.Combine(__SOURCE_DIRECTORY__, "file.txt")
          SearchWord = "file" }

    let result = getTotalWordAccurences query

    let expected = 3

    Assert.Equal(expected, result)

    // Cleanup
    File.Delete(Path.Combine(__SOURCE_DIRECTORY__, "file.txt"))
