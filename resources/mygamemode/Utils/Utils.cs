using System;
using GTANetworkAPI;

namespace mygamemode.Utils
{
    class Utils
    {
        public static string ReturnRPName(Player player)
        {
            string RPName = player.Name.Replace('_',' ');
            return RPName;
        }
    }
}
