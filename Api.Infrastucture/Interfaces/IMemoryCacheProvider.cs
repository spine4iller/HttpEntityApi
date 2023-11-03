using Api.Infrastructure.Entities;

namespace Api.Infrastructure.Interfaces
{
    public interface IMemoryCacheProvider
    {
        void Set(Guid entityId, Entity entity);
        Entity? Get(Guid entityId);
    }
}