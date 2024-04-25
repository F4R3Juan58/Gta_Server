using System;
using GTANetworkAPI;

namespace mygamemode.ParametrosPlayer
{
    internal class vida
    {
        public void Vida(Player player)
        {
            int playerHealth = NAPI.Player.GetPlayerHealth(player);
            NAPI.ClientEvent.TriggerClientEvent(player, "UpdateVida", playerHealth);
        }
    }
}
