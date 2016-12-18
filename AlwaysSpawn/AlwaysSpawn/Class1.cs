using log4net;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MiNET;

namespace AlwaysSpawn
{
    [Plugin(PluginName = "AlwaysSpawn", Description = "AlwaysSpawn for minet", PluginVersion = "1.0", Author = "haniokasai")]
    public class Class1 : Plugin
    {
        protected override void OnEnable()
        {
            Context.Server.PlayerFactory.PlayerCreated += PlayerFactory_PlayerCreated;//generate player created event
            LogManager.GetLogger("[AlwaysSpawn] Loaded");
        }

        private void PlayerFactory_PlayerCreated(object sender, PlayerEventArgs e)
        {
            var player = e.Player;
            player.PlayerJoin += Player_PlayerJoin;//generate player join event
        }

        private void Player_PlayerJoin(object sender, PlayerEventArgs e)
        {
            Player player = e.Player;
            player.Teleport(player.Level.SpawnPoint);//tp player to spawnpoint
        }
    }
}
