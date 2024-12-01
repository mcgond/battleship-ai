using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using Battleship.AI.Engine.Extensions;

namespace Battleship.AI.Engine.Test.Fixture
{
    public class EngineFixture
    {
        public EngineFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAIServices();
            serviceCollection.AddSingleton(typeof(ILogger<>), typeof(NullLogger<>));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }

    [CollectionDefinition("Engine Collection")]
    public class EngineFixtureCollection : ICollectionFixture<EngineFixture>
    {
        // Needed so [CollectionDefinition] can be applied to test files
    }
}
