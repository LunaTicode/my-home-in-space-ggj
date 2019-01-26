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

public class Planet : MonoBehaviour
{
	[System.Serializable]
	public class Resources
	{
		public float Iron;
		public float Oxygen;
		public float Water;

		public float IronStorage = 100;
		public float OxygenStorage = 100;
		public float WaterStorage = 100;
	}

	[SerializeField] private Resources _resources;
	public Resources _Resources { get { return this._resources; } }

	private interface IPrivateData
	{
		int ScienceLevel { get; set; }
	}

	[System.Serializable]
	public class DataPlanet : IPrivateData
	{
		[SerializeField] private BaseDataPlanet _baseDataPlanet;

		public int ScienceLevel_ { get; private set; } = 1;
		int IPrivateData.ScienceLevel { get { return this.ScienceLevel_; } set { this.ScienceLevel_ = value; } }

		public float _IronProduction { get { return this._baseDataPlanet._BaseIronProduction * this.ScienceLevel_; } }
		public float _OxygenProduction { get { return this._baseDataPlanet._BaseOxygenProduction * this.ScienceLevel_; } }
		public float _WaterProduction { get { return this._baseDataPlanet._BaseWaterProduction * this.ScienceLevel_; } }
	}

	[SerializeField] private DataPlanet _data;
	public DataPlanet _Data { get { return this._data; } }

	private IPrivateData _privateData { get { return this._data; } }

	//

	[SerializeField] private float _selfRotationSpeed = 5f;
	[SerializeField] private float _rotationSpeed = 5f;

	[SerializeField] private Transform _star;

	private void RotateSelf()
	{
		this.transform.Rotate(Vector3.up * this._selfRotationSpeed, Space.Self);
	}

	private Vector3 _rotationAxis;

	public void RotateAround(Transform transform)
	{
		this.transform.RotateAround(transform.position, this._rotationAxis, this._rotationSpeed);
	}

	[SerializeField] private PlanetView _planetView;
	[SerializeField] private RectTransform _orbitIndicator;

	public void UpdateResources()
	{
		this._resources.Iron += this._data._IronProduction;
		this._resources.Oxygen += this._data._OxygenProduction;
		this._resources.Water += this._data._WaterProduction;

		this._planetView.UpdateData();
	}

	private void Update()
	{
		this.RotateSelf();
		this.RotateAround(this._star);

		this.UpdateResources();
	}

	private void Awake()
	{
		this._planetView.Display(this);

		this._rotationAxis = Quaternion.Euler(0f, 0f, 90f) * (this.transform.position - this._star.position).normalized;

		if (this._orbitIndicator != null)
		{
			this._orbitIndicator.localRotation = Quaternion.LookRotation(this._rotationAxis);

			float bias = 0.25f + Mathf.Lerp(-0.35f, 0.95f, Mathf.Abs(this.transform.position.x) / 8f); // lol :)
			float value = Mathf.Abs(this.transform.position.x) - bias;

			this._orbitIndicator.localScale = new Vector3(value, value, value);
		}
	}
}
