public class PawnDetector : AbstractPhysicTrigger<IPawn>
{
    public bool IsPawnDetected { get; private set; }
    public IPawn TriggeredPawn => _objectsInTrigger[0];

    protected override void OnTriggerEntered(IPawn enteredObject)
    {
        UpdateDetection();
    }

    private void UpdateDetection()
    {
        IsPawnDetected = _objectsInTrigger.Count == 1;
    }

    protected override void OnTriggerExited(IPawn exitedObject)
    {
        UpdateDetection();
    }
}
