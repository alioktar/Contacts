using Microsoft.AspNetCore.Routing;
using System.Linq;
using System.Text.RegularExpressions;

namespace Contacts.ApiHost
{
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            var asd = Regex.Matches(value.ToString(), "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)").OfType<Match>().Select(m => m.Value).ToArray();
            return value == null ? null : string.Join('-', Regex.Matches(value.ToString(), "(^[a-z]+|[A-Z]+(?![a-z])|[A-Z][a-z]+)").OfType<Match>().Select(m => m.Value).ToArray()).ToLower();
        }
    }
}
