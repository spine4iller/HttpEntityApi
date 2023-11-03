using Api.Infrastructure.Profiles;
using AutoMapper;

namespace Api.Tests
{
    public class MappingProfileTests
	{
		[Fact]
		public void MappingProfile_WhenMappingIncorrect_ThenThrowsException()
		{
			var config = new MapperConfiguration(cfg =>
				cfg.AddProfile<MappingProfile>());
			config.AssertConfigurationIsValid();
		}
	}
}
