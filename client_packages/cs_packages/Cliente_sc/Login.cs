 using System;
 using RAGE;

namespace Cliente_sc
{
    public class Login : Events.Script
    {
        RAGE.Ui.HtmlWindow LoginCEF = null;
        public Login() 
        { 
            LoginCEF = new RAGE.Ui.HtmlWindow("package://Login/Login.html");

            Events.Add("LoginInfoClient", SendLoginInfoToServer);
            Events.Add("ShowLoginCEF", ShowLoginPage);
            Events.Add("InvalidUserPass", InvalidUserPass);
        }

        public void SendLoginInfoToServer(object [] args)
        {
            Events.CallRemote("LoginInfoFromClient", (string)args[0], (string)args[0]);
        }

        public void ShowLoginPage(object[] args)
        {
            bool flag= (bool)args[0];
            LoginCEF.Active= flag;
            RAGE.Ui.Cursor.Visible= flag;
            Chat.Show(!flag);
            RAGE.Elements.Player.LocalPlayer.FreezePosition(flag);
        }

        public void InvalidUserPass(object[] args)
        {
            LoginCEF.ExecuteJs("InvalidUserPass()");
        }
    }
}
