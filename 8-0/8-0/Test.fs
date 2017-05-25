module Test

open Program
open NUnit.Framework
open FsUnit

[<Test>]
let ``test hwpro``() = 
    paigeInfoDownloder "http://hwproj.me/courses/20"
    testUrlList.Length |> should equal 6
