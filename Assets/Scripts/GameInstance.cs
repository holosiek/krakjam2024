using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    private static GameInstance _gameInstance;

    public static GameInstance Instance
    {
        get
        {
            if (_gameInstance == null)
            {
                Initialize();
            }

            return _gameInstance;
        }
    }

    private static void Initialize()
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
        }
        else
        {
            Debug.LogError("More than 1 gameinstance found!!!");
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void Awake()
    {
        Initialize();
    }
}
