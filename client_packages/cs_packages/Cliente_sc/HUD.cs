using System;
using RAGE;

namespace Cliente_sc
{
    public class HUD : Events.Script
    {
        RAGE.Ui.HtmlWindow HudCEF = null;

        public HUD()
        {
            HudCEF = new RAGE.Ui.HtmlWindow("package://HUD/hud.html");

            Events.Add("ProgressBar", ProgressBarToClient);
            Events.Add("ShowHudCEF", ShowLoginPage);
            Events.Add("UpdateVida", UpdateVida);
            Events.Add("UpdateArmadura", UpdateArmadura);
            Events.Add("UpdateComida", UpdateComida);
            Events.Add("UpdateBebida", UpdateBebida);
        }

        public void ProgressBarToClient(object[] args)
        {
            HudCEF.ExecuteJs($"UpdateVida({args[0]})");
            HudCEF.ExecuteJs($"UpdateArmadura({args[1]})");
            HudCEF.ExecuteJs($"UpdateComida({args[2]})");
            HudCEF.ExecuteJs($"UpdateBebida({args[3]})");
        }

        public void ShowLoginPage(object[] args)
        {
            bool flag = (bool)args[0];
            HudCEF.Active = flag;
        }

        public void UpdateVida(object[] args)
        {
            int percentage = (int)(args[0]);
            RAGE.Chat.Output($"Evento 'UpdateVida' recibido del servidor con el valor: {percentage}");
            HudCEF.ExecuteJs($"UpdateVida({percentage})");
        }

        public void UpdateArmadura(object[] args)
        {
            int percentage = (int)(args[0]);
            RAGE.Chat.Output($"Evento 'UpdateArmadura' recibido del servidor con el valor: {percentage}");
            HudCEF.ExecuteJs($"UpdateArmadura({percentage})");
        }

        public void UpdateComida(object[] args)
        {
            int percentage = (int)(args[0]);
            HudCEF.ExecuteJs($"UpdateComida({percentage})");
        }

        public void UpdateBebida(object[] args)
        {
            int percentage = (int)(args[0]);
            HudCEF.ExecuteJs($"UpdateBebida({percentage})");
        }
    }
}
