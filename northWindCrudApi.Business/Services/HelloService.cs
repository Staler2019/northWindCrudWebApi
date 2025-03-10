using northWindCrudApi.Business.IServices;

namespace northWindCrudApi.Business.Services;

public class HelloService :IHelloService
{
    public string SayHello(string name)
    {
        return $"Hello {name}";
    }
}
