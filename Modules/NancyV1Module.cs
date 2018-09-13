using System;
using System.Threading;
using System.Threading.Tasks;
using Nancy;

public class NancyV1Module : NancyModule
{
    public NancyV1RouteBuilder Get => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Get);
    public NancyV1RouteBuilder Put => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Put);
    public NancyV1RouteBuilder Post => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Post);
    public NancyV1RouteBuilder Patch => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Patch);
    public NancyV1RouteBuilder Delete => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Delete);
    public NancyV1RouteBuilder Head => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Head);
    public NancyV1RouteBuilder Options => new NancyV1RouteBuilder(this, NancyV1RouteBuilder.HttpMethod.Options);
}

public class NancyV1RouteBuilder
{
    public enum HttpMethod
    {
        Get,
        Put,
        Post,
        Delete,
        Head,
        Options,
        Patch
    }

    private NancyModule _module;
    private HttpMethod _httpMethod;

    public NancyV1RouteBuilder(NancyModule module, HttpMethod httpMethod)
    {
        _module = module;
        _httpMethod = httpMethod;
    }

    private void UpgradeSync(string name, string path, Func<dynamic, object> value)
    {
            switch (_httpMethod)
            {
                case HttpMethod.Get:
                    _module.Get(path, value, null, name);
                    break;
                case HttpMethod.Put:
                    _module.Put(path, value, null, name);
                    break;
                case HttpMethod.Post:
                    _module.Post(path, value, null, name);
                    break;
                case HttpMethod.Delete:
                    _module.Delete(path, value, null, name);
                    break;
                case HttpMethod.Head:
                    _module.Head(path, value, null, name);
                    break;
                case HttpMethod.Patch:
                    _module.Patch(path, value, null, name);
                    break;
                case HttpMethod.Options:
                    _module.Options(path, value, null, name);
                    break;
            }
    }

    private void UpgradeAsync(string name, string path, Func<dynamic, CancellationToken, Task<object>> value)
    {
        switch (_httpMethod)
        {
            case HttpMethod.Get:
                _module.Get(path, value, null, name);
                break;
            case HttpMethod.Put:
                _module.Put(path, value, null, name);
                break;
            case HttpMethod.Post:
                _module.Post(path, value, null, name);
                break;
            case HttpMethod.Delete:
                _module.Delete(path, value, null, name);
                break;
            case HttpMethod.Head:
                _module.Head(path, value, null, name);
                break;
            case HttpMethod.Patch:
                _module.Patch(path, value, null, name);
                break;
            case HttpMethod.Options:
                _module.Options(path, value, null, name);
                break;
        }
    }

    public Func<dynamic, CancellationToken, Task<object>> this[string path, bool async]
    {
        set => UpgradeAsync(null, path, value);
    }

    public Func<dynamic, CancellationToken, Task<object>> this[string name, string path, bool async]
    {
        set => UpgradeAsync(null, path, value);
    }

    public Func<dynamic, object> this[string name, string path]
    {
        set => UpgradeSync(name, path, value);
    }
   
    public Func<dynamic, object> this[string path]
    {
        set => UpgradeSync(null, path, value);
    }    
}