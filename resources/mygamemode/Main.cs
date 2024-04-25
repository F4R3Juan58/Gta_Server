using System;
using System.Timers;
using GTANetworkAPI;

namespace mygamemode
{
    public class Main : Script
    {
        private Timer timer;

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Util.ConsoleOutput("El recurso se ha iniciado correctamente.");

            // Configurar el temporizador para que se ejecute cada segundo
            timer = new Timer(1000);
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true; // Configurar el temporizador para que se ejecute repetidamente
            timer.Enabled = true; // Habilitar el temporizador para que comience a ejecutarse
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            // Detener y liberar el temporizador cuando el recurso se detenga
            timer.Stop();
            timer.Dispose();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateArmor();
            UpdateHealth();
        }

        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player)
        {
            NAPI.Util.ConsoleOutput($"{player.Name} se ha conectado.");
            NAPI.ClientEvent.TriggerClientEvent(player, "ShowLoginCEF", true);
            NAPI.ClientEvent.TriggerClientEvent(player, "ShowHudCEF", false);
            NAPI.ClientEvent.TriggerClientEvent(player, "ShowVehicleCEF", false);
        }

        [ServerEvent(Event.PlayerSpawn)]
        public void OnPlayerSpawn(Player player)
        {
            NAPI.Chat.SendChatMessageToAll($"{player.Name} ha aparecido.");
        }

        [RemoteEvent("LoginInfoFromClient")]
        public void LoginInfoFromClient(Player player, string user, string password)
        {
            if (user.Equals("user", StringComparison.OrdinalIgnoreCase) && password.Equals("user", StringComparison.OrdinalIgnoreCase))
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "ShowLoginCEF", false);
                NAPI.ClientEvent.TriggerClientEvent(player, "ShowHudCEF", true);
            }
            else
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "InvalidUserPass");
            }
        }

        private void UpdateArmor()
        {
            NAPI.Task.Run(() =>
            {
                foreach (var player in NAPI.Pools.GetAllPlayers())
                {
                    int armor = NAPI.Player.GetPlayerArmor(player);
                    NAPI.ClientEvent.TriggerClientEvent(player, "UpdateArmadura", armor);
                }
            });
        }

        private void UpdateHealth()
        {
            NAPI.Task.Run(() =>
            {
                foreach (var player in NAPI.Pools.GetAllPlayers())
                {
                    int health = NAPI.Player.GetPlayerHealth(player);
                    NAPI.ClientEvent.TriggerClientEvent(player, "UpdateVida", health);
                }
            });
        }

        [RemoteEvent("Spawn")]
        public void SpawnVehicle(Player player, string vehicle)
        {
            ParametrosVehicle.SpawnVehicle.Spawn(vehicle, player);
            NAPI.ClientEvent.TriggerClientEvent(player, "ShowVehicleCEF", false);

        }

    }
}
