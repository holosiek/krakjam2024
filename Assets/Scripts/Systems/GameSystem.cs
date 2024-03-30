using UnityEngine;

public class GameSystem : MonoBehaviour, IGameSystem
{
	public virtual void Initialize() { }
	public virtual void OnNewSceneInitialized() { }
	public virtual void OnSceneReady() { }
	public virtual void OnSceneStarting() { }
	public virtual void OnPreSceneChange() { }
}
