using UnityEngine;

public class FullScreenEffectSystem : GameSystem
{
	[SerializeField]
	private Material _fullScreenMaterial;

	[SerializeField]
	private ModifierTag _exampleFullScreenModifierTag;

	[SerializeField]
	private ModifierTag _quakeModeModifierTag;
	
	private ModifierSystem _modifierSystem;
	private bool _isGreenscreened;
	private bool _isQuakeMode;
	private float _saturation = 0;

	private static readonly int _testColor = Shader.PropertyToID("_TestColor");
	private static readonly int _quakeMode = Shader.PropertyToID("_QuakeMode");
	private static readonly int _saturationAndContrast = Shader.PropertyToID("_SaturationAndContrast");

	public float Saturation
	{
		get => _saturation;
		set
		{
			_saturation = Mathf.Clamp(value, 0, 1);
			_fullScreenMaterial.SetFloat(_saturationAndContrast, _saturation);
		}
	}

	public void Start()
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
		_fullScreenMaterial.SetInt(_quakeMode, 0);
		_isGreenscreened = false;
		_isQuakeMode = false;
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
		
		if (!_isQuakeMode && _modifierSystem.HasModifierTag(_quakeModeModifierTag))
		{
			_fullScreenMaterial.SetInt(_quakeMode, 1);
			_isQuakeMode = true;
		}
		if (_isQuakeMode && !_modifierSystem.HasModifierTag(_quakeModeModifierTag))
		{
			_fullScreenMaterial.SetInt(_quakeMode, 0);
			_isQuakeMode = false;
		}
	}
}
