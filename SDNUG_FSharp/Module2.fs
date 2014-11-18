module Module2
    type Car (make : string, model : string, year : int) =
        let numOfTires = 0 // This is private (no member to back it)
        member x.Make = make // This is effectively a readonly property
        member x.Model = model
        member x.Year = year
        member x.Print() =
            let car = Car("BMW", "435", 2015)
            printfn "Make %s, model %s, year %d" car.Make car.Model car.Year |> ignore

    type Phone (os : string, maker : string) =
        member val OperatingSystem = os with get, set // Initialize a property with a default value
        member x.Maker = maker
        // When I had this as os PrintPhone only printed the initial value...
        member x.PrintPhone() =
            printfn "OS: %s" x.OperatingSystem 
                        
    let printPhone() =
        let phone = Phone("iOS8.1", "Apple")
        phone.PrintPhone()
        phone.OperatingSystem <- "iOS8.1.1"
        phone.PrintPhone()

