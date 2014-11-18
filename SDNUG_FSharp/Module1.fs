module Module1
    let sayHelloWorld() = "Hello World"
    let saySomethingShort x y = x + " " + y 
    let sayHelloTo = saySomethingShort "Hello"
    let saySomethingElseShort x = (fun y -> x + " " + y)
