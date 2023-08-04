using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;

public class TestWebAppFactory<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{
}