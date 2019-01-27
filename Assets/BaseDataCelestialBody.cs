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

[CreateAssetMenu(fileName = "[Base Data Celestial Body] name", menuName = "Celestial Bodies/[Base Data Celestial Body]")]
public class BaseDataCelestialBody : ScriptableObject
{
	[SerializeField] private string _name;
	public string _Name { get { return this._name; } }

	[TextArea]
	[SerializeField] private string _description;
	public string _Description { get { return this._description; } }

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(BaseDataCelestialBody))]
[CanEditMultipleObjects]
public class BaseDataCelestialBodyEditor : Editor
{
#pragma warning disable 0219, 414
	private BaseDataCelestialBody _sBaseDataCelestialBody;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sBaseDataCelestialBody = this.target as BaseDataCelestialBody;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif