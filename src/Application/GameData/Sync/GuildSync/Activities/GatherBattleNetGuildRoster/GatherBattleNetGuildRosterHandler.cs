﻿using System.Threading;
using System.Threading.Tasks;
using LaDanse.External.BattleNet.Abstractions;
using LaDanse.External.BattleNet.Abstractions.Models.GuildRoster;
using LaDanse.External.Configuration.Abstractions;
using MediatR;

namespace LaDanse.Application.GameData.Sync.GuildSync.Activities.GatherBattleNetGuildRoster
{
    public class GatherBattleNetGuildRosterHandler : IRequestHandler<GatherBattleNetGuildRoster, Roster>
    {
        private readonly ILaDanseConfiguration _laDanseConfiguration;
        private readonly IBattleNetApiClientFactory _battleNetApiClientFactory;

        public GatherBattleNetGuildRosterHandler(
            ILaDanseConfiguration laDanseConfiguration,
            IBattleNetApiClientFactory battleNetApiClientFactory)
        {
            _laDanseConfiguration = laDanseConfiguration;
            _battleNetApiClientFactory = battleNetApiClientFactory;
        }

        public async Task<Roster> Handle(GatherBattleNetGuildRoster request, CancellationToken cancellationToken)
        {
            var battleNetApiClient = await _battleNetApiClientFactory.CreateClientAsync(
                ApiRegion.Eu,
                _laDanseConfiguration.BattleNetConfiguration().BattleNetClientId(),
                _laDanseConfiguration.BattleNetConfiguration().BattleNetClientSecret());

            return await battleNetApiClient
                .GuildApi()
                .GuildRosterAsync(request.RealmSlug, request.GuildSlug);
        }
    }
}