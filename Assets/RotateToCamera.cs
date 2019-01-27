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

public class RotateToCamera : MonoBehaviour
{
	private void LateUpdate()
	{
		Vector3 forward = CameraController.Instance_._Camera.transform.position - this.transform.position;
		//forward.x = 0f;

		this.transform.rotation = Quaternion.LookRotation(-forward);
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(RotateToCamera))]
[CanEditMultipleObjects]
public class RotateToCameraEditor : Editor
{
#pragma warning disable 0219, 414
	private RotateToCamera _sRotateToCamera;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sRotateToCamera = this.target as RotateToCamera;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif