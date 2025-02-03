module Program

open System
open SpreadsheetEngine
open FSharp.Text.Lexing
//open SpreadsheetLexer
//open SpreadsheetParser

[<EntryPoint>]
let main argv =
    let spreadsheet = Spreadsheet()
    
    let rec loop () =
        printf ">> "
        let input = Console.ReadLine()
        if input = "exit" then
            printfn "Goodbye!"
        else
            try
                let lexbuf = LexBuffer<char>.FromString(input)
                let statement = SpreadsheetParser.statement SpreadsheetLexer.token lexbuf
                spreadsheet.EvaluateStatement(statement)
            with
            | ex -> printfn "Error: %s" ex.Message
            loop()

    loop()
    0