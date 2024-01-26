using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class InputSystem : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    [SerializeField]
    private InputSystemUIInputModule _inputModule;

    private PlayerInputActions _inputActionAsset;

    public PlayerInputActions PlayerInputAction => _inputActionAsset;

    private void Awake()
    {
        _inputActionAsset = new PlayerInputActions();
        //_playerInput.actions = _inputActionAsset.asset;
        //_inputModule.actionsAsset = _inputActionAsset.asset;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
