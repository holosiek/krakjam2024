using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifierNotification : MonoBehaviour
{
    [SerializeField]
    private float _displayInOutAnimationTime;

    [SerializeField]
    private float _displayTime;

    [SerializeField]
    private AbstractActivable _onModifierDisplayActivable;

    [SerializeField]
    private Image _modifierImage;

    [SerializeField]
    private TMP_Text _modifierText;

    [SerializeField]
    private CanvasGroup _notificationContainer;

    private Queue<Modifier> _modifierQueue = new Queue<Modifier>();

    private Coroutine _notificationDisplay;

    public void ShowNotificaction(Modifier modifier)
    {
        _modifierQueue.Enqueue(modifier);

        if (_modifierQueue.Count == 1)
        {
            PlayNextNotification();
        }
    }

    public void PlayNextNotification()
    {
        var modifier = _modifierQueue.Peek();

        if (_notificationDisplay != null)
        {
            StopCoroutine(_notificationDisplay);
        }
        _modifierImage.sprite = modifier.Image;
        _modifierText.SetText(modifier.Text);
        _notificationDisplay = StartCoroutine(DisplayNotification());
    }

    private IEnumerator DisplayNotification()
    {
        yield return NotificationFadeIn();

        _onModifierDisplayActivable?.Activate();
        yield return new WaitForSeconds(_displayTime);

        yield return NotificationFadeOut();

        _modifierQueue.Dequeue();

        if (_modifierQueue.Count != 0)
        {
            PlayNextNotification();
        }
        else
        {
            _notificationDisplay = null;
        }
    }

    private IEnumerator NotificationFadeIn()
    {
        float inTimer = 0f;
        _notificationContainer.alpha = 0;

        while (inTimer < _displayInOutAnimationTime)
        {
            inTimer += Time.deltaTime;
            _notificationContainer.alpha = inTimer / _displayInOutAnimationTime;
            yield return null;
        }

        _notificationContainer.alpha = 1;
    }

    private IEnumerator NotificationFadeOut()
    {
        float outTimer = 0f;

        while (outTimer < _displayInOutAnimationTime)
        {
            outTimer += Time.deltaTime;
            _notificationContainer.alpha = (_displayInOutAnimationTime - outTimer) / _displayInOutAnimationTime;
            yield return null;
        }
        _notificationContainer.alpha = 0;
    }
}
