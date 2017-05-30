module Test 

open Program
open NUnit.Framework
open FsUnit
open System.Threading

[<Test>]
let ``Test 0 count`` () = 
    let countdown = new CountdownEvent(0)  
    countdown.Signal |> should equal true

[<Test>]
let ``Test threading`` () = 
    let countdown = new CountdownEvent(2)  
    let mutable counter = 0
    let asuncfun = 
         async{
            counter <- counter + 1
            countdown.Wait()
        }
    Async.Start(asuncfun)
    Thread.Sleep 100
    countdown.Signal() |> ignore
    Thread.Sleep 100
    counter |> should equal 1
