module Functions

type Functions() =
    static member Sin (x: float) = sin x
    static member Cos (x: float) = cos x
    static member Tan (x: float) = tan x
    static member Sqrt (x: float) = sqrt x
    static member Pow (x: float, y: float) = x ** y

    