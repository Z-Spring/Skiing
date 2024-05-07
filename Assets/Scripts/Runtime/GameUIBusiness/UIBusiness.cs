namespace Skiing2.GameRules
{
    public class UIBusiness
    {
        public static void Enter(UIBusinessContext ctx)
        {
            UI.SettingPanelOpen(ctx.gameUIContext);
        }

        public static void Exit(UIBusinessContext ctx)
        {
            UI.SettingPanelClose(ctx.gameUIContext);
        }

        public static void OnSettingButtonClick(UIBusinessContext ctx)
        {
            SkiingLog.Log("SettingButtonClick");
            //todo: open setting panel
        }
        
        public static void TearDown(UIBusinessContext ctx)
        {
            Exit(ctx);
        }
    }
}