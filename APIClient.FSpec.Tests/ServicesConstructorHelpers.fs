module ServicesConstructorHelpers
open HttpMock
open System.Collections.Generic
open System.Configuration
open FSpec
open FSpec.Dsl
open VersionOne.SDK.APIClient

let private BASE_URL = "http://localhost:9191"
let private MOCK_SERVER = "MockServer"

let private setUpMockServer (context : TestContext) mockServer = context.Set MOCK_SERVER mockServer
let private getMockServer (context : TestContext) = context.Get<IHttpServer> MOCK_SERVER

let configure context = 
 let mockServer = HttpMockRepository.At BASE_URL
 setUpMockServer context mockServer
 ConfigurationManager.AppSettings.Set("V1Url", BASE_URL)

let createConnector =
 V1Connector.WithInstanceUrl(BASE_URL)
  .WithUserAgentHeader("ServicesConstructorTests", "0.0")
  .WithUsernameAndPassword("admin", "admin")
  .Build()

let configureRoute (context : TestContext) (route: string) (payload: string) =
 getMockServer(context)
  .Stub(fun s -> s.Get(route).Return(payload))
  .OK()

let assertRouteCalled (context : TestContext) (route: string) = 
 getMockServer(context).AssertWasCalled(fun s -> s.Get(route)) |> ignore

let assertRouteNotCalled (context : TestContext) (route: string) =
 getMockServer(context).AssertWasNotCalled(fun s -> s.Get(route)) |> ignore