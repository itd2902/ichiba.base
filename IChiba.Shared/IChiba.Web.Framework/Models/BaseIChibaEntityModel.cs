using System;

namespace IChiba.Web.Framework.Models
{
    public partial class BaseIChibaEntityModel : BaseIChibaModel
    {
        /// <summary>
        /// Gets or sets model identifier
        /// </summary>
        public virtual string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
