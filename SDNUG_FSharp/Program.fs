// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open Module1
open Module2


[<EntryPoint>]
let main argv = 
    printfn "%A" (sayHelloWorld())
    printfn "%A" (saySomethingShort "Hello" "World")
    printfn "%A" (sayHelloTo "World")
    printfn "%A" (saySomethingElseShort "Hello" "World")
    //printCar()
    0 // return an integer exit code