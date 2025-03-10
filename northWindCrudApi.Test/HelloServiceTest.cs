using Microsoft.Extensions.DependencyInjection;
using northWindCrudApi.Business.IServices;
using northWindCrudApi.Business.Services;

namespace northWindCrudApi.Test;

public class HelloFixture
{
    public IServiceProvider ServiceProvider { get; }

    public HelloFixture()
    {
        var services = new ServiceCollection();
        services.AddScoped<IHelloService, HelloService>();
        ServiceProvider = services.BuildServiceProvider();
    }
}

public class HelloServiceTest(HelloFixture fixture) : IClassFixture<HelloFixture>
{
    private readonly IHelloService _service = fixture.ServiceProvider.GetRequiredService<IHelloService>();


    [Fact]
    public void Test_SayHello()
    {
        // Act
        var result = _service.SayHello("World");

        // Assert
        Assert.Equal("Hello World", result);
    }
}
