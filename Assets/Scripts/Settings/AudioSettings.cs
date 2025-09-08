using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    private const string MasterVolumeName = "MasterVolume";
    private const string SoundsVolumeName = "SoundsVolume";
    private const string MusicVolumeName = "MusicVolume";
    private const int MinVolume = -80;
    private const int VolumeModifier = 20;

    [SerializeField] private AudioMixer _mixer;

    private float _masterVolume = 0;
    private bool _isSoundOn = true;

    private void Start()
    {
        _mixer.GetFloat(MasterVolumeName, out _masterVolume);
    }

    public void ChangeMasterVolume(float volume)
    {
        var calculatedVolume = ConvertVolume(volume);
        
        if(_isSoundOn)
            _mixer.SetFloat(MasterVolumeName, calculatedVolume);
        
        _masterVolume = calculatedVolume;
    }

    public void ChangeSoundsVolume(float volume)
    {
        _mixer.SetFloat(SoundsVolumeName, ConvertVolume(volume));
    }

    public void ChangeMusicVolume(float volume)
    {
        _mixer.SetFloat(MusicVolumeName, ConvertVolume(volume));
    }

    public void Mute(bool isSoundOn)
    {
        _isSoundOn = isSoundOn;
        
        if (isSoundOn)
            _mixer.SetFloat(MasterVolumeName, _masterVolume);
        else
            _mixer.SetFloat(MasterVolumeName, MinVolume);
    }

    private float ConvertVolume(float volume) => 
        Mathf.Log10(volume) * VolumeModifier;
}