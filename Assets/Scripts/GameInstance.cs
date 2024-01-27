using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    [SerializeField]
    public List<GameSystem> Systems;

    private static GameInstance _gameInstance;
    private static UiSystem _uiSystem;

    public static GameInstance Instance => _gameInstance;

    public static UiSystem UiSystem => _uiSystem;

    private void Initialize()
    {
        var objs = FindObjectsOfType<GameInstance>();

        if (objs.Length == 0)
        {
            var obj = new GameObject("Game Instance", typeof(GameInstance));
            DontDestroyOnLoad(obj);
            _gameInstance = obj.GetComponent<GameInstance>();
        }
        else if (objs.Length == 1)
        {
            _gameInstance = objs[0];
            DontDestroyOnLoad(_gameInstance);
            UpdateSystemList();
        }
        else
        {
            Debug.LogError("More than 1 gameinstance found, destroying other ones.");
            Destroy(gameObject);
        }
    }

    private static void UpdateSystemList()
    {
        var systems = FindObjectsOfType<GameSystem>();

        foreach (var sys in systems)
        {
            if (sys is UiSystem uiSystem)
            {
                _uiSystem = uiSystem;
            }

            bool exists = false;
            foreach (var systemInside in Instance.Systems)
            {
                if (systemInside == sys)
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                Instance.Systems.Add(sys);
            }
        }
    }

    public T Get<T>() where T : GameSystem
    {
        foreach (var system in Instance.Systems)
        {
            if (system is T gameSystem)
            {
                return gameSystem;
            }
        }

        return null;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ShowGameOverScreen()
    {
        Get<DataSystem>().AddNewBestTime(Get<TimerSystem>().GetTime());
        UiSystem.GameOverScreen.ShowGameOverScreen();
    }

    public void RestartGame()
    {
        ChangeScene(SceneManager.GetActiveScene().name);
        Get<TimerSystem>().ResetTimer();
        Get<ModifierSystem>().RestartModifiers();
        UiSystem.ModifierList.ResetModifiers();
        UiSystem.HealthBar.SetByPercent(1);
    }

    public void Awake()
    {
        Initialize();
    }
}
