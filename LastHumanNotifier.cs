
using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System.Collections.Generic;
using PlayerRoles;

namespace LastHumanPlugin
{
    public class LastHumanPlugin : Plugin<Config>
    {
        public override string Name => "Last Human Notifier";
        public override string Author => "CrazyLab";
        public override Version Version { get; } = new(1, 0, 0);
        public override Version RequiredExiledVersion => new(9, 6, 0);

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Died += OnPlayerDied;
            Exiled.Events.Handlers.Player.Spawned += OnPlayerSpawned;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Died -= OnPlayerDied;
            Exiled.Events.Handlers.Player.Spawned -= OnPlayerSpawned;

            base.OnDisabled();
        }

        private void OnPlayerDied(DiedEventArgs ev)
        {
            CheckLastHuman();
        }

        private void OnPlayerSpawned(SpawnedEventArgs ev)
        {
            CheckLastHuman();
        }

        private void CheckLastHuman()
        {
            List<Player> humans = new();

            foreach (Player player in Player.List)
            {
                if (player.Role.Team == Team.ChaosInsurgency ||
                    player.Role.Team == Team.FoundationForces ||
                    player.Role.Team == Team.OtherAlive ||
                    player.Role == RoleTypeId.ClassD ||
                    player.Role == RoleTypeId.Scientist ||
                    player.Role == RoleTypeId.FacilityGuard)
                {
                    if (player.IsAlive)
                        humans.Add(player);
                }
            }

            if (humans.Count == 1)
            {
                Player lastHuman = humans[0];

                // رسالة خاصة لأخر شخص
                lastHuman.Broadcast(5, "<size=20><color=red><b>⚠️You the last human in Facility</b></color></size>");

                // رسالة للجميع
                foreach (Player player in Player.List)
                {
                    if (player != lastHuman)
                        player.Broadcast(5, $"<size=20><color=red><b>⚠️ {lastHuman.Nickname} The last!</b></color></size>");
                }
            }
        }
    }
}