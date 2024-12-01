using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Engine.Service.HitShipTracking;
using Battleship.AI.Engine.Service.Hunt;
using Battleship.AI.Engine.Service.Offense;
using Battleship.AI.Engine.Service.ShipFit;
using Battleship.AI.Engine.Service.Target;
using Battleship.AI.Engine.Strategy.Offense.Hunt;
using Battleship.AI.Engine.Strategy.Offense.Target;

namespace Battleship.AI.Engine.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddAIServices(this IServiceCollection services)
        {
            services.AddTransient<HighScoreStrategy>();
            services.AddTransient<LowScoreStrategy>();
            services.AddTransient<RandomScoreStrategy>();

            services.AddTransient<DetermineShipDirectionStrategy>();
            services.AddTransient<SinkShipStrategy>();

            services.AddSingleton<IHitShipTrackingService, HitShipTrackingService>();
            services.AddTransient<IHuntService, HuntService>();
            services.AddTransient<IOffenseService, OffenseService>();
            services.AddTransient<IShipFitService, ShipFitService>();
            services.AddTransient<ITargetService, TargetService>();
        }
    }
}
