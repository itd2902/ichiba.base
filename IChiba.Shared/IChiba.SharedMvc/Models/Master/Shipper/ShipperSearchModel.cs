﻿using IChiba.Core.Domain;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public class ShipperSearchModel : ISearchModel
    {
        public string Keywords { get; set; }

        public ActiveStatus Status { get; set; }

        public string LanguageId { get; set; }

        public int PageSize { get; set; }
    }
}
