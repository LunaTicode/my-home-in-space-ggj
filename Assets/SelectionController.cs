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

public class SelectionController : MonoBehaviourSingleton<SelectionController>
{
	[SerializeField] private CelestialBodyInfoView _celestialBodyInfoView;

	[SerializeField] private LayerMask _hitLayerMask;

	private CelestialBody _selectedCelestialBody;

	public void Raycast()
	{
		Ray ray = CameraController.Instance_._Camera.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out RaycastHit raycastHit, 100000f, this._hitLayerMask, QueryTriggerInteraction.Collide))
		{
			CelestialBody celestialBody = raycastHit.collider.GetComponent<CelestialBody>();

			if (celestialBody != null)
			{
				this._celestialBodyInfoView.Display(celestialBody);

				CameraController.Instance_._Target.SetParent(celestialBody.transform, false);
			}

			if (!this._celestialBodyInfoView.Visible_)
				this._celestialBodyInfoView.Show();
		}
		else if (this._celestialBodyInfoView.Visible_)
		{
			this._celestialBodyInfoView.Hide();
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			this.Raycast();
		}
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(SelectionController))]
[CanEditMultipleObjects]
public class SelectionControllerEditor : Editor
{
#pragma warning disable 0219, 414
	private SelectionController _sSelectionController;
#pragma warning restore 0219, 414

	private void OnEnable()
	{
		this._sSelectionController = this.target as SelectionController;
	}

	public override void OnInspectorGUI()
	{
		this.DrawDefaultInspector();
	}
}
#endif