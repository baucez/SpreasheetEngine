module LangTypes

type Value = 
    | Number of float
    | Text of string
    | Error of int
    
type Expr =
    | Value of Value
    | Cell of string
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr
    | Range of string * string
    | Function of string * Expr list

type Statement = 
    | Assign of string * Expr
    | Remove of string
    | Eval of string


