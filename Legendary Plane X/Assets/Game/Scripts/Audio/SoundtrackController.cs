using UnityEngine;
using UnityEngine.Audio;

public class SoundtrackController : MonoBehaviour
{
    [SerializeField]
    private AudioSource _soundtrackAudiosource;

    [SerializeField]
    private AudioClip[] _soundtracks;

    private static bool IsPlaying = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (!IsPlaying)
            PlayRandomSoundtrackLoop();
    }

    private void PlayRandomSoundtrackLoop()
    {
        AudioClip randomClip = _soundtracks[Random.Range(0, _soundtracks.Length)];
        _soundtrackAudiosource.clip = randomClip;
        _soundtrackAudiosource.Play();

        IsPlaying = true;

        Invoke("PlayRandomSoundtrackLoop", randomClip.length);
    }
}
