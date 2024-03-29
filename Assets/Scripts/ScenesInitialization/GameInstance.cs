using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
	[SerializeField]
	private List<IGameSystem> _systems;

	private List<ISceneObject> _sceneObjects = new();

	private static GameInstance _gameInstance;
	private static UiSystem _uiSystem;
	private static ModifierSystem _modifierSystem;

	private static bool _isGameInstanceInitialized;

	public static GameInstance Instance => _gameInstance;
	public static UiSystem UiSystem => _uiSystem;
	public static ModifierSystem ModifierSystem => _modifierSystem;

	public void Awake()
	{
		GameInitialization();
	}

	private void GameInitialization()
	{
		if (!_isGameInstanceInitialized)
		{
			GameInstanceInitialization();
			SystemsInitialization();
			InitializeScene();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void GameInstanceInitialization()
	{
		_gameInstance = this;
		DontDestroyOnLoad(this);
		_isGameInstanceInitialized = true;
	}

	private void SystemsInitialization()
	{
		FetchSystems();
		_systems.ForEach(system => system.Initialize());
	}

	private void InitializeScene()
	{
		_sceneObjects.Clear();
		_sceneObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<ISceneObject>().ToList();

		_systems.ForEach(system => system.OnNewSceneInitialized());
		_sceneObjects.ForEach(sceneObject => sceneObject.OnSystemsInitialized());
		_sceneObjects.ForEach(sceneObject => sceneObject.OnBeforeSceneReady());
		_systems.ForEach(system => system.OnSceneReady());
		_sceneObjects.ForEach(sceneObject => sceneObject.OnAfterSceneReady());
	}

	private void FetchSystems()
	{
		_systems = GetComponentsInChildren<IGameSystem>().ToList();

		foreach (var system in _systems)
		{
			if (system is UiSystem uiSystem)
			{
				_uiSystem = uiSystem;
			}

			if (system is ModifierSystem modifierSystem)
			{
				_modifierSystem = modifierSystem;
			}
		}
	}

	public T Get<T>() where T : GameSystem
	{
		foreach (var system in _systems)
		{
			if (system is T gameSystem)
			{
				return gameSystem;
			}
		}

		return null;
	}

	public async Task ChangeScene(string sceneName)
	{
		_sceneObjects.ForEach(sceneObject => sceneObject.OnPreSceneChange());

		var handle = SceneManager.LoadSceneAsync(sceneName);

		while (!handle.isDone)
		{
			await Task.Yield();
		}

		InitializeScene();
	}
}
