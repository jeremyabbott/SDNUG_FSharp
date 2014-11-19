module Module5

    let printMatchedExpression result =
        printfn "%s" result

    // Default pattern matching syntax
    let getCodeValue code =
        match code with
            | "A" -> "Awesome"
            | "B" -> "Best"
            | "C" -> "Common"
            | _ -> "Unknown Code Type" // Wild card pattern

    printMatchedExpression (getCodeValue "A")
    printMatchedExpression (getCodeValue "Z")

    // Short hand pattern matching syntax
    let getCodeValue' =
        function
            | "A" -> "Awesome"
            | "B" -> "Best"
            | "C" -> "Common"
            | _ -> "Unknown Code Type" // Wild card pattern

    printMatchedExpression (getCodeValue' "A")
    printMatchedExpression (getCodeValue' "Z")

    // Short hand pattern matching syntax
    let getCodeValue'' =
        function
            | "A" -> "Awesome"
            | "B" -> "Best"
            | "C" -> "Common"
            | c -> sprintf "Code: %s was input, but does not have a known value" c // Wild card pattern

    printMatchedExpression (getCodeValue'' "A")
    printMatchedExpression (getCodeValue'' "Z")