using UnityEngine;

public class ActivableChangeScene : AbstractActivable
{
    [SerializeField]
    private string _sceneName;

    public override void Activate()
    {
        GameInstance.Instance.ChangeScene(_sceneName);
    }

    public override void Deactivate() { }
}
