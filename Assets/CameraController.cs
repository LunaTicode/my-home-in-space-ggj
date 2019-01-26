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

public class CameraController : MonoBehaviourSingleton<CameraController>
{
	[SerializeField] private Camera _camera;
	public Camera _Camera { get { return this._camera; } }

#if UNITY_EDITOR
	private void Reset()
	{
		this._camera = this.GetComponent<Camera>();
	}

	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(CameraController))]
[CanEditMultipleObjects]
public class CameraControllerEditor : Editor
{
#pragma warning disable 0219, 414
	private CameraController _sCameraController;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sCameraController = this.target as CameraController;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif