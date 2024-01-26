using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
    [SerializeField]
    public List<GameSystem> Systems;
    
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
            UpdateSystemList();
        }
        else
        {
            Debug.LogError("More than 1 gameinstance found!!!");
        }
    }

    private static void UpdateSystemList()
    {
        var systems = FindObjectsOfType<GameSystem>();
        
        foreach (var sys in systems)
        {
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

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void Awake()
    {
        Initialize();
    }
}
