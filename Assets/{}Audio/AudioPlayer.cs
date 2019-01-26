using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

[RequireComponent(typeof(AudioSource))]
public abstract class AudioPlayer<TPlayer> : MonoBehaviourSingleton<TPlayer>
    where TPlayer : AudioPlayer<TPlayer>
{
    [SerializeField] private AudioSource _audioSource;
    
    public void PlayClipOneShot(AudioClip audioClip, float volumeScale)
    {
        this._audioSource.PlayOneShot(audioClip);
    }

    public void PlayClipOneShot(AudioClip audioClip)
    {
        this.PlayClipOneShot(audioClip, this._audioSource.volume);
    }

    private static IEnumerator PlayFadingProcess(AudioSource audioSource, float fadeTime, AudioClip audioClip, float delayTime, float volumeScale)
    {
        fadeTime /= 2f;

        float progress = 1f - volumeScale;

        if (audioSource.isPlaying)
        {
            float initialVolumeScale = audioSource.volume;

            while (progress <= fadeTime)
            {
                float calculatedProgress = (progress / fadeTime);

                audioSource.volume = Mathf.Lerp(initialVolumeScale, 0f, calculatedProgress);

                progress += Time.unscaledDeltaTime;

                yield return null;
            }
        }

        yield return new WaitForSecondsRealtime(delayTime);

        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();

        progress = 0f;
        while (progress <= fadeTime)
        {
            float calculatedProgress = (progress / fadeTime);

            audioSource.volume = Mathf.Lerp(0f, volumeScale, calculatedProgress);

            progress += Time.unscaledDeltaTime;

            yield return null;
        }

        audioSource.volume = volumeScale;
    }

    private Coroutine _playFadingProcess;

    public void PlayFading(AudioSource audioSource, float fadeTime, AudioClip audioClip, float delayTime, float volumeScale)
    {
        if (this._playFadingProcess != null)
            this.StopCoroutine(this._playFadingProcess);

        this._playFadingProcess = this.StartCoroutine(AudioPlayer<TPlayer>.PlayFadingProcess(audioSource, fadeTime, audioClip, delayTime, volumeScale));
    }

    public void PlayFading(float fadeTime, AudioClip audioClip, float delayTime, float volumeScale)
    {
        this.PlayFading(this._audioSource, fadeTime, audioClip, delayTime, volumeScale);
    }

    public void PlayFading(float fadeTime, AudioClip audioClip, float delayTime)
    {
        this.PlayFading(this._audioSource, fadeTime, audioClip, delayTime, this._audioSource.volume);
    }

    public void PlayFading(float fadeTime, AudioClip audioClip)
    {
        this.PlayFading(this._audioSource, fadeTime, audioClip, 0f, this._audioSource.volume);
    }

#if UNITY_EDITOR
    private void Reset()
    {
        this._audioSource = this.GetComponent<AudioSource>();
        if (this._audioSource != null)
        {
            this._audioSource.playOnAwake = false;
        }
    }
#endif
}
