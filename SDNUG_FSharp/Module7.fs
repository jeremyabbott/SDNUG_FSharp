module Module7

    open System

    let createAsyncWorkFlow delay name =
        async {
                printfn "Workflow %s started at %O" name DateTime.Now.TimeOfDay
                do! Async.Sleep delay
                printfn "Workflow %s finished at %O" name DateTime.Now.TimeOfDay
                return sprintf "Something from workflow %s at %O" name DateTime.Now.TimeOfDay
        }

    let iThinkIGetIt () =
        let aWorkFlow = async {
                return! createAsyncWorkFlow 1500 "#1"
            }

        let anotherWorkFlow = async {
                return! createAsyncWorkFlow 3500 "#2"
            }
        
        let workFlows = [aWorkFlow; anotherWorkFlow]

        List.toSeq workFlows
        |> Async.Parallel
        |> Async.RunSynchronously
        |> Seq.iter (fun t -> printfn "%s" t)