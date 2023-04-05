using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundButton : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioMixerGroup audioMixerGroup;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = audioMixerGroup;
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
