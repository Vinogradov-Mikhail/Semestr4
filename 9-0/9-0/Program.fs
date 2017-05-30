module Program

open System
open System.Threading

type CountdownEvent(counter) = 
    let manualEvent = new ManualResetEvent(false)
    let mutable count = 
        if counter >= 0 then 
            counter 
        else failwith "Counter < 0"

    member this.Count = count

    member this.Wait() = 
        if count > 0 then
            manualEvent.WaitOne()
        else false

    member this.Signal() = 
        count <- Interlocked.Decrement(&count)
        if count <= 0 then
            manualEvent.Set()
        else false