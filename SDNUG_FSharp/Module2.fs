module Module2

    // The empty parentheses indicate that this function accepts unit
    let buildAList() =
        let rand = System.Random()
        // init expects a count for size
        // and an initilization function
        // 
        List.init 10 (fun _ -> rand.Next(100))

    // mapAList partially applies the map function
    // map function accepts a function and a list
    let mapAList =
        List.map (fun i -> i * i)


    // printAList partial applies the
    // iter function from the List module
    // iter accepts a function and a list
    let printAList =
        List.iter (fun i -> printfn "%i" i) 

    let myList = buildAList()

    // Forward pipelining
    // Forwards the result of a function to the last argument of another function.
    myList |> printAList
    myList |> mapAList |> printAList

    // Functional Composition

    let printMappedList = mapAList >> printAList

    printMappedList (buildAList())
