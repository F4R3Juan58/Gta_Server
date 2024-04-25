using RAGE;

namespace Cliente_sc
{
    internal class Vehicles : Events.Script
    {
        RAGE.Ui.HtmlWindow VehicleCEF = null;
        public Vehicles()
        {
            VehicleCEF = new RAGE.Ui.HtmlWindow("package://Vehicles/vehicles.html");

            Events.Add("ShowVehicleCEF", ShowVehicleCEF);
            Events.Add("Spawn", SpawnVehicles);
        }

        public void ShowVehicleCEF(object[] args)
        {
            bool flag = (bool)args[0];
            VehicleCEF.Active = flag;
            RAGE.Ui.Cursor.Visible = flag;
            Chat.Show(!flag);
            RAGE.Elements.Player.LocalPlayer.FreezePosition(flag);
        }

        public void SpawnVehicles(object[] args)
        {
            Events.CallRemote("Spawn", (string)args[0]);
        }
    }
}
