using UnityEngine;

public class FullScreenEffectSystem : GameSystem
{
	[SerializeField]
	private Material _fullScreenMaterial;

	[SerializeField]
	private ModifierTag _exampleFullScreenModifierTag;
	
	private ModifierSystem _modifierSystem;
	private bool _isGreenscreened;

	private static readonly int _testColor = Shader.PropertyToID("_TestColor");

	public void Awake()
	{
		_modifierSystem = GameInstance.Instance.Get<ModifierSystem>();
		_modifierSystem.OnModifierListUpdate += OnModifierListUpdate;
		CheckModifiers();
	}

	public void OnDestroy()
	{
		_modifierSystem.OnModifierListUpdate -= OnModifierListUpdate;
		ClearModifiers();
	}
	
	private void ClearModifiers()
	{
		_fullScreenMaterial.SetColor(_testColor, Color.white);
		_isGreenscreened = false;
	}

	private void OnModifierListUpdate(Modifier modifier)
	{
		CheckModifiers();
	}

	private void CheckModifiers()
	{
		if (!_isGreenscreened && _modifierSystem.HasModifierTag(_exampleFullScreenModifierTag))
		{
			_fullScreenMaterial.SetColor(_testColor, Color.green);
			_isGreenscreened = true;
		}
		if (_isGreenscreened && !_modifierSystem.HasModifierTag(_exampleFullScreenModifierTag))
		{
			_fullScreenMaterial.SetColor(_testColor, Color.white);
			_isGreenscreened = false;
		}
	}
}
