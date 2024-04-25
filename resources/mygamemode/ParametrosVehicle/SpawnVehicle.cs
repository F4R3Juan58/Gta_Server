using System;
using GTANetworkAPI;

namespace mygamemode.ParametrosVehicle
{
    internal class SpawnVehicle
    {
        // Función para spawnear un vehículo delante del jugador
        public static void Spawn(string vehicleName, Player player)
        {
            // Obtener la posición actual del jugador
            Vector3 playerPosition = player.Position;

            // Calcular la posición delante del jugador
            Vector3 spawnPosition = playerPosition.Around(5);

            // Obtener el modelo del vehículo basado en el nombre
            VehicleHash vehicleHash = (VehicleHash)NAPI.Util.GetHashKey(vehicleName);

            // Comprobar si el modelo del vehículo es válido
            if (!Enum.IsDefined(typeof(VehicleHash), vehicleHash))
            {
                Console.WriteLine($"Error: El nombre del vehículo '{vehicleName}' no es válido.");
                return;
            }

            // Crear el vehículo en la posición calculada y la orientación especificada
            Vehicle vehicle = NAPI.Vehicle.CreateVehicle(vehicleHash, spawnPosition, 0, 0, 0);

            // Comprobar si el vehículo se creó con éxito
            if (vehicle == null)
            {
                Console.WriteLine($"Error: No se pudo crear el vehículo '{vehicleName}'.");
                return;
            }

            // Mensaje de éxito
            Console.WriteLine($"Vehículo '{vehicleName}' spawnado con éxito delante del jugador.");
        }
    }
}
