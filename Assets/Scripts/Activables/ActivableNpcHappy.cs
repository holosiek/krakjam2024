using UnityEngine;

public class ActivableNpcHappy : AbstractActivable
{
    [SerializeField]
    private AiAgent _aiAgent;

    public override void Activate()
    {
        _aiAgent.MakeMeHappy();
    }

    public override void Deactivate()
    {

    }
}
