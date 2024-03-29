using System;
using UnityEngine;

public class OnHealthChangedActivator : MonoBehaviour, ISceneObject
{
	[SerializeField]
	private HealthManager _healthManager;

	[SerializeField]
	private AbstractActivable _activable;

	[SerializeField]
	private bool _activateOnHealthTreshold;

	[SerializeField]
	[Range(0f, 1f)]
	private float _healthTreshold;

	public void OnSystemsInitialized()
	{
		_healthManager.OnHealthChangedEvent += OnHealthChanged;
	}

	private void OnHealthChanged()
	{
		if (!_activateOnHealthTreshold || _healthManager.HealthPercentage <= _healthTreshold)
		{
			_activable.Activate();
		}
	}

	public void OnPreSceneChange()
	{
		Cleanup();
	}

	private void Cleanup()
	{
		if (_healthManager != null)
		{
			_healthManager.OnHealthChangedEvent -= OnHealthChanged;
		}
	}

	private void OnDestroy()
	{
		Cleanup();
	}
}
