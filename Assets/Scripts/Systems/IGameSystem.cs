public interface IGameSystem
{
	void Initialize();
	void OnNewSceneInitialized();
	void OnSceneReady();
	void OnSceneStarting();
	void OnPreSceneChange();
}
