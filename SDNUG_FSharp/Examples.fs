module Examples
    
    let mutable somethingMeaningful = 1

    let someFunc a b =
        let result = somethingMeaningful * (a + b)
        somethingMeaningful <- somethingMeaningful + 1
        result

    let result' = someFunc 1 2
