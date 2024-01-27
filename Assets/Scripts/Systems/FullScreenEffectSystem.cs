using UnityEngine;

public class FullScreenEffectSystem : GameSystem
{
	[SerializeField]
	private Material _fullScreenMaterial;

	[SerializeField]
	private ModifierTag _exampleFullScreenModifierTag;
	
	private ModifierSystem _modifierSystem;

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
	}

	private void OnModifierListUpdate(Modifier modifier)
	{
		CheckModifiers();
	}

	private void CheckModifiers()
	{
		if (_modifierSystem.HasModifierTag(_exampleFullScreenModifierTag))
		{
			_fullScreenMaterial.SetColor(_testColor, Color.green);
		}
	}
}
