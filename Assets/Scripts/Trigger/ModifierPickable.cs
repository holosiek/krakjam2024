public class ModifierPickable: AbstractActivable
{
	public override void Activate()
	{
		GameInstance.Instance.Get<ModifierSystem>().AddNewRandomModifier();
		gameObject.SetActive(false);
	}

	public override void Deactivate() { }
}
