/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

public abstract class AudioPlayerPlaybackEngine<TAudioPlayer> : MonoBehaviour
    where TAudioPlayer : AudioPlayer<TAudioPlayer>
{
    [SerializeField] protected TAudioPlayer audioPlayer;
    [SerializeField] protected AudioPack audioPack;

    [Range(0f, 1f)]
    [SerializeField] protected float volume = 1f;

    [SerializeField] protected float fadeTime = 10f;
    [SerializeField] protected float delayTime = 5f;
    [SerializeField] protected bool playFading = false;

    public void Play()
    {
        if (this.playFading)
        {
            this.audioPlayer.PlayFading(this.fadeTime, this.audioPack.GetRandom(), this.delayTime, this.volume);
        }
        else
        {
            this.audioPlayer.PlayClipOneShot(this.audioPack.GetRandom(), this.volume);
        }
    }

    private void Awake()
    {
        this.Play();
    }

#if UNITY_EDITOR
    private void Reset()
    {
        this.audioPlayer = this.GetComponent<TAudioPlayer>();
    }
#endif
}
