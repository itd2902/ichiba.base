using System.Collections.Generic;
using System.Net;

namespace IChiba.Web.Framework.Models
{
    public interface ISearchModel
    {
        string LanguageId { get; set; }
    }

    public class ActivatesModel
    {
        public IList<string> Ids { get; set; }

        public bool Active { get; set; }

        public ActivatesModel()
        {
            Ids = new List<string>();
            Active = true;
        }
    }

    public class RefreshTokenModel
    {
        public string RefreshToken { get; set; }
    }

    public class IChibaResult
    {
        public bool success { get; set; }

        public string code { get; set; }

        public int httpStatusCode { get; set; }

        public string title { get; set; }

        public string message { get; set; }

        public object data { get; set; }

        public Dictionary<string, IEnumerable<string>> errors { get; set; }

        public IChibaResult()
        {
            success = true;
            httpStatusCode = (int)HttpStatusCode.OK;
            errors = new Dictionary<string, IEnumerable<string>>();
        }
    }
}
