open Module1

[<EntryPoint>]
let main argv = 
    printfn "%A" (sayHelloWorld())
    printfn "%A" (saySomethingShort "Hello" "World")
    printfn "%A" (sayHelloTo "World")
    printfn "%A" (saySomethingElseShort "Hello" "World")
    0 // return an integer exit code