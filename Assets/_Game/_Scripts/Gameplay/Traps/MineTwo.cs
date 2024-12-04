public class MineTwo: BaseMine
{
    public override void CheckActivateRpc(StadesActivate stadesActivate)
    {
        base.CheckActivateRpc(stadesActivate);
        if(stadesActivate == StadesActivate.Enter) ExplodeRpc();
    }
}