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

public class Star : CelestialBody
{
	[SerializeField] private float _selfRotationSpeed = 1f;

	private void RotateSelf()
	{
		this.transform.Rotate(-Vector3.up * this._selfRotationSpeed, Space.Self);
	}

	private void Update()
	{
		this.RotateSelf();
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(Star))]
[CanEditMultipleObjects]
public class StarEditor : Editor
{
#pragma warning disable 0219, 414
	private Star _sStar;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sStar = this.target as Star;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif