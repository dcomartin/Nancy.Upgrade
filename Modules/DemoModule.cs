using System.Threading;
using System.Threading.Tasks;
using Nancy;

public class DemoModule: NancyV1Module 
{
    public DemoModule()
    {
        Get["named", "/sync"] = DoSync;
        Get["/sync/noname"] = DoSync;
        Get["named", "/async/named", true] = DoAsync;
        Get["/async/noname", true] = DoAsync;
    }

    private object DoSync(dynamic o)
    {
        return "Hello World";
    }

    private Task<object> DoAsync(dynamic o, CancellationToken token)
    {
        return Task.FromResult("Hello World" as object);
    }
}