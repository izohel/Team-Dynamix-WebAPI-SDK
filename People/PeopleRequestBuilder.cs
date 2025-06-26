using Itsm.Tdx.WebApi.Exceptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;


namespace Itsm.Tdx.WebApi.People;
public class PeopleRequestBuilder : BaseRequestBuilder
{
    public PeopleRequestBuilder(TdxBaseClient client)
        : base("people",client)
    {

    }
    public PersonSearchRequestBuilder Search => new($"{Path}/search",Client);
    //public PersonLookupRequestBuilder Lookup => new(Client);

    public PersonByIdRequestBuilder this[string uid]
        => new($"{Path}/{uid}", Client);

}
