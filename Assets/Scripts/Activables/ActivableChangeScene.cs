using UnityEngine;

public class ActivableChangeScene : AbstractActivable
{
    [SerializeField]
    private string _sceneName;

    [SerializeField]
    private bool _shouldResetTimer;

    public async override void Activate()
    {
        if (_shouldResetTimer)
        {
            GameInstance.Instance.Get<TimerSystem>().ResetTimer();
        }
        
        await GameInstance.Instance.ChangeScene(_sceneName);
    }

    public override void Deactivate() { }
}
