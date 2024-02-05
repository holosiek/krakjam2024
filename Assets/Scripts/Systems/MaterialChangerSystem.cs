using UnityEngine;

public class MaterialChangerSystem : GameSystem
{
	[SerializeField]
	private Material[] _materials;
	
	[SerializeField]
	private ModifierTag _fasolkaModifierTag;
	
	private ModifierSystem _modifierSystem;
	private static readonly int _fasolkiOn = Shader.PropertyToID("_FasolkiOn");

	private bool _isFasolki = false;

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

	private void OnModifierListUpdate(Modifier modifier)
	{
		CheckModifiers();
	}

	private void ClearModifiers()
	{
		foreach (var mat in _materials)
		{
			if (mat != null)
			{
				mat.SetInt(_fasolkiOn, 0);
			}
		}
		_isFasolki = false;
	}
	
	private void CheckModifiers()
	{
		if (!_isFasolki && _modifierSystem.HasModifierTag(_fasolkaModifierTag))
		{
			foreach (var mat in _materials)
			{
				mat.SetInt(_fasolkiOn, 1);
			}

			_isFasolki = true;
		}

		if (_isFasolki && !_modifierSystem.HasModifierTag(_fasolkaModifierTag))
		{
			foreach (var mat in _materials)
			{
				mat.SetInt(_fasolkiOn, 0);
			}

			_isFasolki = false;
		}
	}
}
