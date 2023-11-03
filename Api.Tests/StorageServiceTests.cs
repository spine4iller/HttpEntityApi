using Api.Infrastructure.Entities;
using Api.Infrastructure.Exceptions;
using Api.Infrastructure.Interfaces;
using Api.Infrastructure.Services;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;

namespace Api.Tests
{
    public class StorageServiceTests
    {
        [Theory, AutoMoqData]
        public void GetEntity_WhenNotExists_ThenThrowException(
            [Frozen] Mock<IMemoryCacheProvider> memoryCache,
            StorageService service,
            Guid entityId)
        {
            memoryCache.Setup(x => x.Get(entityId)).Throws<EntityMissingException>();

            Action act = () => service.GetEntity(entityId);

            act.Should().ThrowExactly<EntityMissingException>();
        }

        [Theory, AutoMoqData]
        public void GetEntity_WhenExists_ThenReturnsEntity(
            [Frozen] Mock<IMemoryCacheProvider> memoryCache,
            StorageService service,
            Entity entity)
        {
            memoryCache.Setup(x => x.Get(entity.Id))
                .Returns(entity);

            Entity? gotEntity = service.GetEntity(entity.Id);

            gotEntity.Should().BeEquivalentTo(entity);
        }

        [Theory, AutoMoqData]
        public void SaveEntity_ShouldSetToCache(
           [Frozen] Mock<IMemoryCacheProvider> memoryCache,
           StorageService service,
           Entity entity)
        {
            service.SaveEntity(entity);

            memoryCache.Verify(x => x.Set(entity.Id, entity), Times.Once);
        }

        [Theory, AutoMoqData]
        public void GetEntity_ShouldGetFromCache(
           [Frozen] Mock<IMemoryCacheProvider> memoryCache,
           StorageService service,
           Guid entityId)
        {
            service.GetEntity(entityId);

            memoryCache.Verify(x => x.Get(entityId), Times.Once);
        }
    }
}