using System.Windows.Forms;

namespace GameServer;

public sealed class ChangeNoobSupportLevel : GMCommand
{
    [FieldDescription(0, Index = 0)]
    public byte Level;

    public override ExecuteCondition Priority => ExecuteCondition.Background;

    public override void ExecuteCommand()
    {
        Config.NoobSupportLevel = Level;
        Config.Save();
        SMain.Main.BeginInvoke(() =>
        {
            SMain.Main.S_NoobSupportLevel.Value = Level;
        });
        SMain.AddCommandLog($"<= @{GetType().Name} The command has been executed, the current support level:{Config.NoobSupportLevel}");
    }
}
