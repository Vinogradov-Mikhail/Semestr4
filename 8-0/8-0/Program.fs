module Program

open System.Net
open System.IO
open System.Text.RegularExpressions

let mutable testUrlList = []

let paigeInfoDownloder(url : string) =
    let format = "<a href=(\"http://([^\"]*\")|\'[^\']*\')"
    let regularExp = new Regex(format)
    
    let getHtmlAsync(url : string) =
        async {
            let webRequest = WebRequest.Create(url)
            use response = webRequest.GetResponse()
            use responseStream = response.GetResponseStream()
            use reader = new StreamReader(responseStream)
            return reader.ReadToEnd()
        }

    let allPaiges = regularExp.Matches(Async.RunSynchronously(getHtmlAsync(url)))

    let downloadHtml(url : string) =
        async {
            try
                let html = Async.StartAsTask(getHtmlAsync(url))
                let! htmlTask = Async.AwaitTask(html)
                do printfn "%s--%d" url htmlTask.Length
            with
                | ex -> printfn "%A" ex.Message
        }
    let allHtml = seq {for uri in allPaiges ->
                        let reg = new Regex(format.Substring(9,24))
                        let html = reg.Match(uri.ToString()).ToString()
                        testUrlList <- html::testUrlList
                        html.Substring(1, html.Length - 2) }

    allHtml 
    |> Seq.map (fun url -> downloadHtml url) 
    |> Async.Parallel 
    |> Async.RunSynchronously 
    |> ignore