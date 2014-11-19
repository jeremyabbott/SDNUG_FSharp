module Module6

    type Person = { FirstName : string; LastName : string }

    let people = [ { FirstName = "Jon"; LastName = "Smith" }; { FirstName = "Jane"; LastName = "Doe" } ]
    let newPerson = { FirstName = "Jon"; LastName = "Doe" }

    // adding someone to a list
    let morePeople = newPerson :: people

    let whereLastNameContains character list =
        let rec lastNameFilter c existingList filteredList =
            match existingList with
            | [] -> filteredList // if the existing list is empty we're done so return the filtered list
            | h :: t when h.LastName.Contains(c) ->
                // we have a match
                // send in the tail and filter character
                // create a new list from the existing filteredList and the matched value
                lastNameFilter c t (h :: filteredList)
            | _ :: t ->
                // append the match to the filteredList
                lastNameFilter c t filteredList
        lastNameFilter character list []

    let printFilteredList () =
        let filteredList : (Person list) = whereLastNameContains "S" morePeople

        printfn "%A" filteredList