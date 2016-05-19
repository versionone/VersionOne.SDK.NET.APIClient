module Main

[<EntryPoint>]
let main argv = 
    System.Reflection.Assembly.GetExecutingAssembly () |> FSpec.TestDiscovery.runSingleAssembly |> ignore
    System.Console.Read()