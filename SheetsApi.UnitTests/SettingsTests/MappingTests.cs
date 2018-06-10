using AutoMapper;
using SheetsApi.Settings;
using Xunit;

namespace SheetsApi.UnitTests.SettingsTests
{
    public class MappingTests
    {
        [Fact]
        public void EnsureMappingsAreCorrect()
        {
            Mapper.Initialize(x => new SheetsMappingProfile());
            Mapper.AssertConfigurationIsValid();
            Mapper.Reset();
        }
    }
}