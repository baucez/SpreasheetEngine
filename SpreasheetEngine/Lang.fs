module Lang

type Expr =
    | Number of float
    | Cell of string
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr

type Statement = 
    | Assign of string * Expr
    | Remove of string
    | Eval of string
