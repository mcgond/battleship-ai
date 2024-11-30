using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Engine.Strategy.Offense.Hunt;

namespace Battleship.AI.Engine.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddAIServices(this IServiceCollection services)
        {
            services.AddTransient<HighScoreStrategy>();
            services.AddTransient<LowScoreStrategy>();
            services.AddTransient<RandomScoreStrategy>();
        }
    }
}
