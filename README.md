# Spreadsheet Engine

A simple spreadsheet engine built in **F#**, allowing users to define and evaluate expressions in cells with dependencies. It automatically updates dependent cells when a value changes.

## Features
- Define cells with expressions (e.g., `A1 = 5 + 3`)
- Support for arithmetic operations (`+`, `-`, `*`, `/`)
- Reference other cells within expressions (`B2 = A1 * 2`)
- Dependency tracking with automatic updates

## TODO list
- Detects circular dependencies
- Support String and Bool types
- Support function calls
- Support range

## Installation
### Prerequisites
- Install [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- Install [FsLexYacc](https://www.nuget.org/packages/FsLexYacc)

### Clone the Repository
```sh
git clone https://github.com/your-username/spreadsheet-engine.git
cd spreadsheet-engine
```

### Build the Project
```sh
dotnet build
```

## Usage
### Defining Cells
```txt
A1 = 10
B1 = A1 + 5
C1 = B1 * 2
```
### Viewing Cell Values
```txt
> eval B1
15
> C1
30
```
### Deleting Cells
```txt
> del A1
```

## License
This project is licensed under the MIT License.

---
Feel free to modify or enhance this engine. Happy coding! 🚀

