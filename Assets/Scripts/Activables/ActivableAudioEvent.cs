using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ActivableAudioEvent : AbstractActivable
{
    [SerializeField]
    private bool _playSound;

    private AudioSource _audioSource;

    private AudioSource AudioSource => _audioSource != null
        ? _audioSource
        : _audioSource = GetComponent<AudioSource>();

    public override void Activate()
    {
        AudioSource.Play();
    }

    public override void Deactivate()
    {
        AudioSource.Stop();
    }

    private void OnValidate()
    {
        if (_playSound)
        {
            AudioSource.Play();
            _playSound = false;
        }
    }
}
