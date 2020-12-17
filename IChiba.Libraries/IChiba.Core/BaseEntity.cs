using IChiba.Caching;
using System;
using LinqToDB.Mapping;

namespace IChiba.Core
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    [Serializable]
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        [PrimaryKey, NotNull]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Get key for caching the entity
        /// </summary>
        public string EntityCacheKey => GetEntityCacheKey(GetType(), Id);

        /// <summary>
        /// Get key for caching the entity
        /// </summary>
        /// <param name="entityType">Entity type</param>
        /// <param name="id">Entity id</param>
        /// <returns>Key for caching the entity</returns>
        public static string GetEntityCacheKey(Type entityType, object id)
        {
            return string.Format(CachingDefaults.EntityCacheKey, entityType.Name.ToLower(), id);
        }
    }
}
