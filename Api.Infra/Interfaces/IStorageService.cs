using Api.Infrastructure.Entities;

namespace Api.Infrastructure.Interfaces;

public interface IStorageService
{
    void SaveEntity(Entity entity);
    Entity? GetEntity(Guid entityId);
}