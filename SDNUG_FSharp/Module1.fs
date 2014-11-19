module Module1
    /// <summary>
    /// Returns Hello World
    /// </summary>
    let sayHelloWorld() = "Hello World"

    /// <summary>
    /// Returns arguments as a concatenated string.
    /// </summary>
    /// <param name="x">First word</param>
    /// <param name="y">Second word</param>
    let saySomethingShort x y = x + " " + y // guess what? The + operator is a function.

    /// <summary>
    /// Say Hello to the passed in argument.
    /// This function partially applies the saySomethingShort function.
    /// </summary>
    let sayHelloTo = saySomethingShort "Hello"

    /// <summary>
    /// Another way of describing how the compiler
    /// rewrites functions that accept multiple arguments.
    /// </summary>
    /// <param name="x">The first word in a two word phrase</param>
    let saySomethingElseShort x = (fun y -> x + " " + y)