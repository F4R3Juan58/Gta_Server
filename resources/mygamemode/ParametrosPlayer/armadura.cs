using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace mygamemode.ParametrosPlayer
{
    internal class armadura
    {
        public void escudo(Player player)
        {
            int playerArmor = NAPI.Player.GetPlayerArmor(player);
            NAPI.ClientEvent.TriggerClientEvent(player, "UpdateArmor", playerArmor);
        }

    }
}
