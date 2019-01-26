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

[CreateAssetMenu(fileName = "[Base Data Planet] name", menuName = "Planet/[Base Data Planet]")]
public class BaseDataPlanet : ScriptableObject
{
	[Min(0f)]
	[SerializeField] private float _baseIronProduction = 0.001f;
	public float _BaseIronProduction { get { return this._baseIronProduction; } }

	[Min(0f)]
	[SerializeField] private float _baseOxygenProduction = 0.001f;
	public float _BaseOxygenProduction { get { return this._baseOxygenProduction; } }

	[Min(0f)]
	[SerializeField] private float _baseWaterProduction = 0.001f;
	public float _BaseWaterProduction { get { return this._baseWaterProduction; } }

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(BaseDataPlanet))]
[CanEditMultipleObjects]
public class BaseDataPlanetEditor : Editor
{
#pragma warning disable 0219, 414
	private BaseDataPlanet _sBaseDataPlanet;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sBaseDataPlanet = this.target as BaseDataPlanet;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif