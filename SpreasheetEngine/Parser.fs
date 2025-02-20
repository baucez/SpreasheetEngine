// Implementation file for parser generated by fsyacc
module SpreadsheetParser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 2 "Parser.fsy"

open LangTypes

# 10 "Parser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | ASSIGN
  | REMOVE
  | EVAL
  | PLUS
  | MINUS
  | TIMES
  | DIVIDE
  | LPAREN
  | RPAREN
  | COLON
  | CELLNAME of (string)
  | TEXT of (string)
  | NUMBER of (float)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_ASSIGN
    | TOKEN_REMOVE
    | TOKEN_EVAL
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIVIDE
    | TOKEN_LPAREN
    | TOKEN_RPAREN
    | TOKEN_COLON
    | TOKEN_CELLNAME
    | TOKEN_TEXT
    | TOKEN_NUMBER
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstatement
    | NONTERM_statement
    | NONTERM_expr

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | ASSIGN  -> 1 
  | REMOVE  -> 2 
  | EVAL  -> 3 
  | PLUS  -> 4 
  | MINUS  -> 5 
  | TIMES  -> 6 
  | DIVIDE  -> 7 
  | LPAREN  -> 8 
  | RPAREN  -> 9 
  | COLON  -> 10 
  | CELLNAME _ -> 11 
  | TEXT _ -> 12 
  | NUMBER _ -> 13 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_ASSIGN 
  | 2 -> TOKEN_REMOVE 
  | 3 -> TOKEN_EVAL 
  | 4 -> TOKEN_PLUS 
  | 5 -> TOKEN_MINUS 
  | 6 -> TOKEN_TIMES 
  | 7 -> TOKEN_DIVIDE 
  | 8 -> TOKEN_LPAREN 
  | 9 -> TOKEN_RPAREN 
  | 10 -> TOKEN_COLON 
  | 11 -> TOKEN_CELLNAME 
  | 12 -> TOKEN_TEXT 
  | 13 -> TOKEN_NUMBER 
  | 16 -> TOKEN_end_of_input
  | 14 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstatement 
    | 1 -> NONTERM_statement 
    | 2 -> NONTERM_statement 
    | 3 -> NONTERM_statement 
    | 4 -> NONTERM_statement 
    | 5 -> NONTERM_expr 
    | 6 -> NONTERM_expr 
    | 7 -> NONTERM_expr 
    | 8 -> NONTERM_expr 
    | 9 -> NONTERM_expr 
    | 10 -> NONTERM_expr 
    | 11 -> NONTERM_expr 
    | 12 -> NONTERM_expr 
    | 13 -> NONTERM_expr 
    | 14 -> NONTERM_expr 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 16 
let _fsyacc_tagOfErrorTerminal = 14

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | ASSIGN  -> "ASSIGN" 
  | REMOVE  -> "REMOVE" 
  | EVAL  -> "EVAL" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIVIDE  -> "DIVIDE" 
  | LPAREN  -> "LPAREN" 
  | RPAREN  -> "RPAREN" 
  | COLON  -> "COLON" 
  | CELLNAME _ -> "CELLNAME" 
  | TEXT _ -> "TEXT" 
  | NUMBER _ -> "NUMBER" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | ASSIGN  -> (null : System.Object) 
  | REMOVE  -> (null : System.Object) 
  | EVAL  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIVIDE  -> (null : System.Object) 
  | LPAREN  -> (null : System.Object) 
  | RPAREN  -> (null : System.Object) 
  | COLON  -> (null : System.Object) 
  | CELLNAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | TEXT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NUMBER _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;7us;65535us;3us;4us;15us;9us;16us;10us;17us;11us;18us;12us;19us;13us;20us;14us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;2us;1us;4us;1us;1us;5us;1us;5us;6us;7us;8us;1us;2us;1us;2us;1us;3us;1us;3us;5us;5us;5us;6us;7us;8us;5us;5us;6us;6us;7us;8us;5us;5us;6us;7us;7us;8us;5us;5us;6us;7us;8us;8us;5us;5us;6us;7us;8us;9us;5us;5us;6us;7us;8us;10us;1us;5us;1us;6us;1us;7us;1us;8us;1us;9us;1us;10us;1us;10us;1us;11us;1us;12us;2us;13us;14us;1us;14us;1us;14us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;7us;9us;15us;17us;19us;21us;23us;29us;35us;41us;47us;53us;59us;61us;63us;65us;67us;69us;71us;73us;75us;77us;80us;82us;|]
let _fsyacc_action_rows = 27
let _fsyacc_actionTableElements = [|3us;32768us;2us;5us;3us;7us;11us;2us;0us;49152us;1us;16388us;1us;3us;5us;32768us;5us;19us;8us;20us;11us;24us;12us;23us;13us;22us;4us;16385us;4us;15us;5us;16us;6us;17us;7us;18us;1us;32768us;11us;6us;0us;16386us;1us;32768us;11us;8us;0us;16387us;2us;16389us;6us;17us;7us;18us;2us;16390us;6us;17us;7us;18us;0us;16391us;0us;16392us;0us;16393us;5us;32768us;4us;15us;5us;16us;6us;17us;7us;18us;9us;21us;5us;32768us;5us;19us;8us;20us;11us;24us;12us;23us;13us;22us;5us;32768us;5us;19us;8us;20us;11us;24us;12us;23us;13us;22us;5us;32768us;5us;19us;8us;20us;11us;24us;12us;23us;13us;22us;5us;32768us;5us;19us;8us;20us;11us;24us;12us;23us;13us;22us;5us;32768us;5us;19us;8us;20us;11us;24us;12us;23us;13us;22us;5us;32768us;5us;19us;8us;20us;11us;24us;12us;23us;13us;22us;0us;16394us;0us;16395us;0us;16396us;1us;16397us;10us;25us;1us;32768us;11us;26us;0us;16398us;|]
let _fsyacc_actionTableRowOffsets = [|0us;4us;5us;7us;13us;18us;20us;21us;23us;24us;27us;30us;31us;32us;33us;39us;45us;51us;57us;63us;69us;75us;76us;77us;78us;80us;82us;|]
let _fsyacc_reductionSymbolCounts = [|1us;3us;2us;2us;1us;3us;3us;3us;3us;2us;3us;1us;1us;1us;3us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;1us;1us;1us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;65535us;65535us;65535us;16386us;65535us;16387us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16394us;16395us;16396us;65535us;65535us;16398us;|]
let _fsyacc_reductions = lazy [|
# 159 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Statement in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startstatement));
# 168 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 25 "Parser.fsy"
                                                   Assign(_1, _3) 
                   )
# 25 "Parser.fsy"
                 : Statement));
# 180 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 26 "Parser.fsy"
                                                   Remove(_2) 
                   )
# 26 "Parser.fsy"
                 : Statement));
# 191 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 27 "Parser.fsy"
                                                   Eval(_2) 
                   )
# 27 "Parser.fsy"
                 : Statement));
# 202 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 28 "Parser.fsy"
                                                   Eval(_1) 
                   )
# 28 "Parser.fsy"
                 : Statement));
# 213 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Expr in
            let _3 = parseState.GetInput(3) :?> Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 32 "Parser.fsy"
                                                       Add(_1, _3) 
                   )
# 32 "Parser.fsy"
                 : Expr));
# 225 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Expr in
            let _3 = parseState.GetInput(3) :?> Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 33 "Parser.fsy"
                                                       Sub(_1, _3) 
                   )
# 33 "Parser.fsy"
                 : Expr));
# 237 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Expr in
            let _3 = parseState.GetInput(3) :?> Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "Parser.fsy"
                                                       Mul(_1, _3) 
                   )
# 34 "Parser.fsy"
                 : Expr));
# 249 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Expr in
            let _3 = parseState.GetInput(3) :?> Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "Parser.fsy"
                                                       Div(_1, _3) 
                   )
# 35 "Parser.fsy"
                 : Expr));
# 261 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 36 "Parser.fsy"
                                                       Sub(Value( Number 0.0), _2) 
                   )
# 36 "Parser.fsy"
                 : Expr));
# 272 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 37 "Parser.fsy"
                                                       _2 
                   )
# 37 "Parser.fsy"
                 : Expr));
# 283 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> float in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "Parser.fsy"
                                                       Value (Number _1) 
                   )
# 38 "Parser.fsy"
                 : Expr));
# 294 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "Parser.fsy"
                                                       Value (Text _1) 
                   )
# 39 "Parser.fsy"
                 : Expr));
# 305 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "Parser.fsy"
                                                       Cell _1 
                   )
# 40 "Parser.fsy"
                 : Expr));
# 316 "Parser.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            let _3 = parseState.GetInput(3) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "Parser.fsy"
                                                       Range(_1, _3) 
                   )
# 41 "Parser.fsy"
                 : Expr));
|]
# 329 "Parser.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions = _fsyacc_reductions.Value;
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 17;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let statement lexer lexbuf : Statement =
    engine lexer lexbuf 0 :?> _
