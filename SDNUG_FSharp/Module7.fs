module Module7

    open System
    //open Microsoft.FSharp.Control  // Async.* is in this module.

    let userTimerWithAsync () = 

        // create a timer and associated async event
        let timer = new System.Timers.Timer(2000.0)
        // Timer event will do something when timer.Elapsed fires.
        let timerEvent = Async.AwaitEvent (timer.Elapsed) |> Async.Ignore

        // start
        printfn "Waiting for timer at %O" DateTime.Now.TimeOfDay
        timer.Start()

        // keep working
        printfn "Doing something useful while waiting for event"

        // process will unblock once timerEvent goes off.
        Async.RunSynchronously timerEvent

        // done
        printfn "Timer ticked at %O" DateTime.Now.TimeOfDay

    let countInParallel () =
        let sleepWorkflow  = async {
                printfn "Starting child sleep workflow at %O" DateTime.Now.TimeOfDay
                do! Async.Sleep 2000
                printfn "Finished child sleep workflow at %O" DateTime.Now.TimeOfDay
            }

        let nestedWorkflow  = async{

                printfn "Starting parent"
                let! childWorkflow = Async.StartChild sleepWorkflow

                // give the child a chance and then keep working
                do! Async.Sleep 100
                printfn "Parent doing something useful while waiting "

                // block on the child
                let! result = childWorkflow

                // done
                printfn "Finished parent" 
            }

        // run the whole workflow
        Async.RunSynchronously nestedWorkflow 
    
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