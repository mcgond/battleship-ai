using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Engine.Service.Defense;
using Battleship.AI.Engine.Service.HitShipTracking;
using Battleship.AI.Engine.Service.Hunt;
using Battleship.AI.Engine.Service.Offense;
using Battleship.AI.Engine.Service.ScoreCalculation;
using Battleship.AI.Engine.Service.ShipFit;
using Battleship.AI.Engine.Service.SquareScoreDetermination;
using Battleship.AI.Engine.Service.Target;
using Battleship.AI.Engine.Strategy.Defense.Placement;
using Battleship.AI.Engine.Strategy.Offense.Hunt;
using Battleship.AI.Engine.Strategy.Offense.Misc;
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

            services.AddTransient<RandomPlacementStrategy>();

            services.AddTransient<MarkSquaresAsMissStrategy>();

            services.AddTransient<IDefenseService, DefenseService>();
            services.AddSingleton<IHitShipTrackingService, HitShipTrackingService>();
            services.AddTransient<IHuntService, HuntService>();
            services.AddTransient<IOffenseService, OffenseService>();
            services.AddTransient<IScoreCalculationService, ScoreCalculationService>();
            services.AddTransient<IShipFitService, ShipFitService>();
            services.AddTransient<ISquareScoreDeterminationService, SquareScoreDeterminationService>();
            services.AddTransient<ITargetService, TargetService>();
        }
    }
}
