module SpreadsheetLexer

open FSharp.Text.Lexing
open System
open SpreadsheetParser/// Rule token
val token: lexbuf: LexBuffer<char> -> token
