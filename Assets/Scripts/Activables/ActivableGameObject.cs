public class ActivableGameObject : AbstractActivable
{
    public override void Activate()
    {
        gameObject.SetActive(true);
        IsActive = true;
    }

    public override void Deactivate()
    {
        gameObject.SetActive(false);
        IsActive = false;
    }
}