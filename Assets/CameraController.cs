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

	[SerializeField] private Transform _target;
	public Transform _Target { get { return this._target; } }

	[SerializeField] private float[] _scrollDistances;
	private int _scrollDistanceIndex;

	[SerializeField] private float _smoothingSpeed = 3.5f;

	[SerializeField] private Cinemachine.CinemachineVirtualCamera _virtualCamera;

	private Cinemachine.CinemachineFramingTransposer _framingTransposer;

	private void LateUpdate()
	{
		float mouseScrollWheelAxis = Input.GetAxisRaw("Mouse ScrollWheel");

		if (Mathf.Abs(mouseScrollWheelAxis) > 0f)
		{
			if (mouseScrollWheelAxis < 0f && this._scrollDistanceIndex < this._scrollDistances.Length - 1)
				this._scrollDistanceIndex++;
			else if (mouseScrollWheelAxis > 0f && this._scrollDistanceIndex > 0)
				this._scrollDistanceIndex--;
		}

		this._framingTransposer.m_CameraDistance = Mathf.Lerp(this._framingTransposer.m_CameraDistance, this._scrollDistances[this._scrollDistanceIndex], this._smoothingSpeed * Time.deltaTime);
	}

	protected override void Awake()
	{
		base.Awake();

		this._framingTransposer = this._virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>();

		this._scrollDistanceIndex = this._scrollDistances.Length - 1;
	}

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