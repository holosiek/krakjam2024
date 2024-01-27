public class ActivableShowWonScreen : AbstractActivable
{
    public override void Activate()
    {
        GameInstance.Instance.ShowGameWonScreen();
    }

    public override void Deactivate() { }
}
