using Api.Infrastructure.Entities;
using Api.Infrastructure.Exceptions;
using Api.Infrastructure.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Api.Infrastructure.Services
{
    public class MemoryCacheProvider : IMemoryCacheProvider
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheProvider(IMemoryCache cache)
        {
            _cache = cache;
        }
        public Entity? Get(Guid entityId)
        {
            if (_cache.TryGetValue(entityId, out Entity? entity))
            {
                return entity;
            }

            throw new EntityMissingException($"entity not found by id {entityId}");
        }

        public void Set(Guid entityId, Entity entity)
        {
            _cache.Set(entityId, entity);
        }
    }
}
