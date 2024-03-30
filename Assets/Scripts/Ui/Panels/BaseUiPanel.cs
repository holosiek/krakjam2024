using System;
using UnityEngine;

public class BaseUiPanel : MonoBehaviour
{
	public event Action OnPanelOpenedEvent;
	public event Action OnPanelClosedEvent;
	public bool IsOpened => isActiveAndEnabled;

	public virtual void Initialize()
	{

	}

	public void Open()
	{
		gameObject.SetActive(true);
		InternalOnOpen();
		OnPanelOpenedEvent?.Invoke();
	}

	protected virtual void InternalOnOpen()
	{

	}

	public void Close()
	{
		gameObject.SetActive(false);
		InternalOnClose();
		OnPanelClosedEvent?.Invoke();
	}

	protected virtual void InternalOnClose()
	{

	}

	public virtual void Cleanup()
	{

	}
}
