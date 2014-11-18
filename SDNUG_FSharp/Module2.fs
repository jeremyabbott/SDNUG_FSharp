module Module2
    type Car (make: string, model: string, year:int) =
        member x.Make = make
        member x.Model = model
        member x.Year = year

    let printCar() =
        let car = Car("BMW", "435", 2015)
        printfn "Make %s, model %s, year %d" car.Make car.Model car.Year |> ignore