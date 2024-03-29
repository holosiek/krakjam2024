using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AbstractSubmitHandler : MonoBehaviour, ISubmitHandler, IPointerClickHandler
{
	public void OnSubmit(BaseEventData eventData)
	{
		OnSubmit();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		OnSubmit();
	}

	protected abstract void OnSubmit();
}