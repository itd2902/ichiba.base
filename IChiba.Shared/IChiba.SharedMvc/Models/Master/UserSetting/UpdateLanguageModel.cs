using System;
using System.Collections.Generic;
using System.Text;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class UpdateLanguageModel : BaseIChibaEntityModel
    {
        public string UserId { get; set; }

        public string LanguageId { get; set; }

        public string AppId { get; set; }
    }
}
