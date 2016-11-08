#r @"FakeLib.dll"

open Fake 
open Fake.Git
open Fake.Testing
open System
open System.IO

let testAssemblies = "tests/**/bin/Release/*.Tests.dll"
let solution = "BioInformatics.Project3.sln"
Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

Target "Clean" (fun _ ->
    CleanDirs ["bin"; "temp"]
)

Target "Build" (fun _ ->
    !! solution
    |> MSBuildRelease "" "Rebuild"
    |> ignore
)

Target "RunTests" (fun _ ->
    !! testAssemblies
    |> xUnit2 (fun p ->
            {p with
                ToolPath = "/home/travis/build/MNie/BioInformatics.Project3/xunit.runner.console.2.1.0/tools/xunit.console.exe"
                NoAppDomain = isMono
                ShadowCopy = false })
)

"Clean"
  ==> "Build"
  ==> "RunTests"

RunTargetOrDefault "RunTests"