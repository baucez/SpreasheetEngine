module SpreadsheetEngine

open System.Collections.Generic
open LangTypes

type Spreadsheet() =
    let cellValues = Dictionary<string, Value>()
    let cellFormulas = Dictionary<string, Expr>()
    let dependencies = Dictionary<string, HashSet<string>>()
    let dependents = Dictionary<string, HashSet<string>>()

    /// Evaluates an expression recursively
    let rec eval (expr: Expr) : Value =
        match expr with
        | Value v -> match v with
                     | Number n -> Number n
                     | Text t -> Text t
                     | Error e -> Error e
        | Cell name ->
            if cellValues.ContainsKey(name) then cellValues.[name]
            else Error 1 //failwithf "Cell %s is not defined" name

        | Add (l, r) -> 
            match eval l, eval r with
            | Number nl, Number nr -> Number (nl + nr)
            | _ -> Error 2 // Indicating invalid addition operation
        | Sub (l, r) -> 
            match eval l, eval r with
            | Number nl, Number nr -> Number (nl - nr)
            | _ -> Error 2 // Indicating invalid addition operation
        | Mul (l, r) ->
            (match eval l, eval r with
            | Number nl, Number nr -> Number (nl * nr)
            | _ -> Error 2 // Indicating invalid addition operation
            )
        | Div (l, r) ->
            (match eval l, eval r with
            | Number nl, Number nr -> if nr = 0.0 then Error 3
                                      else Number (nl / nr)
            | _ -> Error 2 // Indicating invalid addition operation
            )
        | _ -> Error 5

    /// Evaluate a cell
    let evalCell cellName =
        if cellFormulas.ContainsKey cellName then
            try
                let value = eval cellFormulas.[cellName]
                cellValues.[cellName] <- value
                match value with
                | Number n  -> printfn "%s = %f" cellName n
                | Text t    -> printfn "%s = \"%s\"" cellName t
                | Error e   -> printfn "%s = ERROR(%d)" cellName e
            with
                Failure msg -> printfn "%s Error" cellName
        else
            printfn "%s Not Defined" cellName


    /// Updates dependencies and dependents
    let updateDependencies cell expr =
        // Remove old dependencies
        if dependencies.ContainsKey(cell) then
            for dep in dependencies.[cell] do
                dependents.[dep].Remove(cell) |> ignore
        dependencies.[cell] <- HashSet<string>()

        let rec findDependencies exp =
            match exp with
            | Cell name ->
                dependencies.[cell].Add(name) |> ignore
                if not (dependents.ContainsKey(name)) then dependents.[name] <- HashSet<string>()
                dependents.[name].Add(cell) |> ignore
            | Add (l, r) | Sub (l, r) | Mul (l, r) | Div (l, r) ->
                findDependencies l
                findDependencies r
            | Function (_, args) -> 
                for arg in args do
                    findDependencies arg
            | _ -> ()
        findDependencies expr
        //TODO Add cylce detection

    /// Recalculates all dependent cells recursively
    let rec updateDependents cell =
        if dependents.ContainsKey(cell) then
            for dep in dependents.[cell] do
                evalCell dep
                updateDependents dep

    /// Assigns an expression to a cell and updates dependents
    member this.SetCell(name: string, expr: Expr) =
        updateDependencies name expr
        cellFormulas.[name] <- expr
        evalCell name
        updateDependents name

    /// Gets the value of a cell
    member this.GetCellValue(name: string) =
        if cellValues.ContainsKey(name) then Some cellValues.[name]
        else None

    /// Remove a cell
    member this.RemoveCell(cellName: string) =
        cellValues.Remove cellName |> ignore
        cellFormulas.Remove cellName |> ignore
        dependencies.Remove cellName |> ignore
        updateDependents cellName

    /// Evaluate a statement
    member this.EvaluateStatement(statement: Statement) =
        match statement with
        | Assign(cellName, expr) -> this.SetCell(cellName, expr)
        | Remove(cellName) -> this.RemoveCell(cellName)
        | Eval(cellName) -> evalCell(cellName)
