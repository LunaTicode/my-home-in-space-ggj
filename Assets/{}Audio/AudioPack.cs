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

[CreateAssetMenu(fileName = "[Audio Pack] name", menuName = "Audio/[Audio Pack]")]
public class AudioPack : ScriptableObject
{
    [SerializeField] private AudioClip[] _audioClips;

    private int _selectedAudioClipIndex = 0;

    public AudioClip _SelectedAudioClip { get { return this._audioClips[this._selectedAudioClipIndex]; } }

    public AudioClip Previous(bool loop = true)
    {
        this._selectedAudioClipIndex = loop ?
            ((--this._selectedAudioClipIndex % this._audioClips.Length) + this._audioClips.Length) % this._audioClips.Length :
            Mathf.Clamp(--this._selectedAudioClipIndex, 0, this._audioClips.Length - 1);

        return this._audioClips[this._selectedAudioClipIndex];
    }

    public AudioClip Next(bool loop = true)
    {
        this._selectedAudioClipIndex = loop ?
            ((++this._selectedAudioClipIndex % this._audioClips.Length) + this._audioClips.Length) % this._audioClips.Length :
            Mathf.Clamp(++this._selectedAudioClipIndex, 0, this._audioClips.Length - 1);

        return this._audioClips[this._selectedAudioClipIndex];
    }

    public AudioClip GetRandom()
    {
        return this._audioClips[Random.Range(0, this._audioClips.Length)];
    }
}
