using IChiba.Caching;
using IChiba.Core;
using IChiba.Core.Events;
using IChiba.Services.Events;

namespace IChiba.Services.Caching
{
    public abstract partial class CacheEventConsumer<TEntity> :
        IConsumer<EntityInsertedEvent<TEntity>>,
        IConsumer<EntityUpdatedEvent<TEntity>>,
        IConsumer<EntityDeletedEvent<TEntity>>
        where TEntity : BaseEntity
    {
        protected readonly IIChibaCacheManager _cacheManager;

        protected CacheEventConsumer(IIChibaCacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        /// <summary>
        /// entity
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <param name="entityEventType">Entity event type</param>
        protected virtual void ClearCache(TEntity entity, EntityEventType entityEventType)
        {
            ClearCache(entity);
        }

        /// <summary>
        /// Clear cache data
        /// </summary>
        /// <param name="entity">Entity</param>
        protected virtual void ClearCache(TEntity entity)
        {
        }

        /// <summary>
        /// Removes items by key prefix
        /// </summary>
        /// <param name="prefixCacheKey">String key prefix</param>
        protected virtual void RemoveByPrefix(string prefixCacheKey)
        {
            _cacheManager.HybridProvider.RemoveByPrefix(prefixCacheKey);
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="cacheKey">Key of cached item</param>
        protected virtual void Remove(string cacheKey)
        {
            _cacheManager.HybridProvider.Remove(cacheKey);
        }

        /// <summary>
        /// Handle entity inserted event
        /// </summary>
        /// <param name="eventMessage">Event message</param>
        public virtual void HandleEvent(EntityInsertedEvent<TEntity> eventMessage)
        {
            var entity = eventMessage.Entity;
            ClearCache(entity, EntityEventType.Insert);
        }

        /// <summary>
        /// Handle entity updated event
        /// </summary>
        /// <param name="eventMessage">Event message</param>
        public virtual void HandleEvent(EntityUpdatedEvent<TEntity> eventMessage)
        {
            var entity = eventMessage.Entity;

            _cacheManager.HybridProvider.Remove(entity.EntityCacheKey);
            ClearCache(eventMessage.Entity, EntityEventType.Update);
        }

        /// <summary>
        /// Handle entity deleted event
        /// </summary>
        /// <param name="eventMessage">Event message</param>
        public virtual void HandleEvent(EntityDeletedEvent<TEntity> eventMessage)
        {
            var entity = eventMessage.Entity;

            _cacheManager.HybridProvider.Remove(entity.EntityCacheKey);
            ClearCache(eventMessage.Entity, EntityEventType.Delete);
        }

        protected enum EntityEventType
        {
            Insert,
            Update,
            Delete
        }
    }
}
