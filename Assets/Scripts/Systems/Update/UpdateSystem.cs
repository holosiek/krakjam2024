using System.Collections.Generic;

public class UpdateSystem : GameSystem
{
	private readonly HashSet<IUpdatable> _updatables = new();
	private readonly HashSet<IFixedUpdatable> _fixedUpdatables = new();
	private readonly HashSet<ILateUpdatable> _lateUpdatables = new();

	private bool _isSceneReady;

	public void Register(IUpdatable updatable)
	{
		_updatables.Add(updatable);
	}

	public void Register(IFixedUpdatable fixedUpdatable)
	{
		_fixedUpdatables.Add(fixedUpdatable);
	}

	public void Register(ILateUpdatable lateUpdatable)
	{
		_lateUpdatables.Add(lateUpdatable);
	}

	public void Deregister(IUpdatable updatable)
	{
		_updatables.Remove(updatable);
	}

	public void Deregister(IFixedUpdatable fixedUpdatable)
	{
		_fixedUpdatables.Remove(fixedUpdatable);
	}

	public void Deregister(ILateUpdatable lateUpdatable)
	{
		_lateUpdatables.Remove(lateUpdatable);
	}

	public override void OnSceneStarting()
	{
		_isSceneReady = true;
	}

	private void Update()
	{
		if (!_isSceneReady)
		{
			return;
		}

		foreach (var updatable in _updatables)
		{
			if (updatable.CanBeUpdated)
			{
				updatable.DoUpdate();
			}
		}
	}

	private void FixedUpdate()
	{
		if (!_isSceneReady)
		{
			return;
		}

		foreach (var fixedUpdatable in _fixedUpdatables)
		{
			if (fixedUpdatable.CanBeUpdated)
			{
				fixedUpdatable.DoFixedUpdate();
			}
		}
	}

	private void LateUpdate()
	{
		if (!_isSceneReady)
		{
			return;
		}

		foreach (var lateUpdatable in _lateUpdatables)
		{
			if (lateUpdatable.CanBeUpdated)
			{
				lateUpdatable.DoLateUpdate();
			}
		}
	}

	public override void OnPreSceneChange()
	{
		_isSceneReady = false;
		_updatables.Clear();
		_fixedUpdatables.Clear();
		_lateUpdatables.Clear();
	}
}
