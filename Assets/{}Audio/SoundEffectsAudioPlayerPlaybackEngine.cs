/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

public class SoundEffectsAudioPlayerPlaybackEngine : AudioPlayerPlaybackEngine<SoundEffectsAudioPlayer>
{
#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(SoundEffectsAudioPlayerPlaybackEngine))]
[CanEditMultipleObjects]
public class SoundEffectsAudioPlayerPlaybackEngineEditor : Editor
{
#pragma warning disable 0219, 414
	private SoundEffectsAudioPlayerPlaybackEngine _sSoundEffectsAudioPlayerPlaybackEngine;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sSoundEffectsAudioPlayerPlaybackEngine = this.target as SoundEffectsAudioPlayerPlaybackEngine;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif