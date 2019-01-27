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

public class CelestialBody : MonoBehaviour
{
	[SerializeField] private BaseDataCelestialBody _data;
	public BaseDataCelestialBody _BaseDataCelestialBody { get { return this._data; } }

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(CelestialBody))]
[CanEditMultipleObjects]
public class CelestialBodyEditor : Editor
{
#pragma warning disable 0219, 414
	private CelestialBody _sCelestialBody;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sCelestialBody = this.target as CelestialBody;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif