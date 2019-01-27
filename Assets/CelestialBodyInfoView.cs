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

public class CelestialBodyInfoView : View
{
	[SerializeField] private TextMeshProUGUI _nameTextField;
	[SerializeField] private TextMeshProUGUI _descriptionTextField;

	public void Display(CelestialBody celestialBody)
	{
		this._nameTextField.text = celestialBody._BaseDataCelestialBody._Name;
		this._descriptionTextField.text = celestialBody._BaseDataCelestialBody._Description;
	}

	[SerializeField] private SoundEffectsAudioPlayerPlaybackEngine _playbackEngine;

	public override void Show()
	{
		base.Show();

		this._playbackEngine.Play();
	}

	public override void Hide()
	{
		base.Hide();

		this._playbackEngine.Play();
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(CelestialBodyInfoView))]
[CanEditMultipleObjects]
public class CelestialBodyInfoViewEditor : ViewEditor
{
#pragma warning disable 0219, 414
	private CelestialBodyInfoView _sCelestialBodyInfoView;
#pragma warning restore 0219, 414

	protected override void OnEnable()
	{
		base.OnEnable();

		this._sCelestialBodyInfoView = this.target as CelestialBodyInfoView;
	}
}
#endif