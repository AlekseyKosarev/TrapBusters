public class MineOne: BaseMine
{
    public override void CheckActivateRpc(StadesActivate stadesActivate)
    {
        base.CheckActivateRpc(stadesActivate);
        if(stadesActivate == StadesActivate.Exit) ExplodeRpc();
    }
}