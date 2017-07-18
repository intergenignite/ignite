using Ignite.Rules.Dto;
using NUnit.Framework;

namespace Ignite.Rules.Test
{
    [TestFixture]
    public class SecurityRepositoryTest
    {
        [Test]
        public void CanLoadAccessLevel()
        {
            var webLoader = new WebLoader();
            var settings = new SettingsStub();
            var repos = new SecurityRepository(webLoader, settings);

//            var fileLoader = new FileLoader();
//            var settings = new SettingsStub()
//                .WithRulesPath(@"C:\dev\ignite\ignite\resource\test\ignite_rules.json").WithSessionMapPath(@"D:\DEV\ignite\resource\test\ignite_session_map.json");
//            var repos = new SecurityRepository(fileLoader, settings);

            RulesDto level = repos.LoadAccessLevel().Result;

            Assert.IsNotNull(level);
            level.AssertNoPropertiesAreNull(new []{ "Identifier" });
        }

        [Test]
        public void CanLoadSessionMap()
        {
            var webLoader = new WebLoader();
            var settings = new SettingsStub();
            var repos = new SecurityRepository(webLoader, settings);

            var level = repos.LoadSessionMap().Result;

            Assert.IsNotNull(level);
            level.AssertNoPropertiesAreNull();
        }
    }
}