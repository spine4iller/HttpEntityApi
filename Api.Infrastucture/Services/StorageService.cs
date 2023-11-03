using Api.Infrastructure.Entities;
using Api.Infrastructure.Interfaces;

namespace Api.Infrastructure.Services
{
    public class StorageService : IStorageService
    {
        private readonly IMemoryCacheProvider _cache;

        public StorageService(IMemoryCacheProvider cache)
        {
            _cache = cache;
        }

        public void SaveEntity(Entity entity)
        {
            _cache.Set(entity.Id,entity);
        }

        public Entity? GetEntity(Guid entityId)
        {
            return _cache.Get(entityId);
        }
    }
}