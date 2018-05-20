using System.Collections.Generic;

namespace StravaApi.StravaModel
{
    public abstract class StravaRequestItem
    {
        public abstract string RequestUrl { get; }
        public abstract IEnumerable<KeyValuePair<string, string>> GetQueryParameters();
    }
}