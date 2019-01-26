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

public class PlanetView : View
{
	private Planet _planet;

	[SerializeField] private ProgressFiller _ironProgressFiller;
	[SerializeField] private ProgressFiller _oxygenProgressFiller;
	[SerializeField] private ProgressFiller _waterProgressFiller;

	public void Display(Planet planet)
	{
		this._planet = planet;
	}

	public void UpdateData()
	{
		this._ironProgressFiller.Fill = this._planet._Resources.Iron / this._planet._Resources.IronStorage;
		this._oxygenProgressFiller.Fill = this._planet._Resources.Oxygen / this._planet._Resources.OxygenStorage;
		this._waterProgressFiller.Fill = this._planet._Resources.Water / this._planet._Resources.WaterStorage;
	}

#if UNITY_EDITOR
	//protected override void OnDrawGizmos()
	//{
	//}
#endif
}

#if UNITY_EDITOR
[CustomEditor(typeof(PlanetView))]
[CanEditMultipleObjects]
public class PlanetViewEditor : ViewEditor
{
#pragma warning disable 0219, 414
	private PlanetView _sPlanetView;
#pragma warning restore 0219, 414

	protected override void OnEnable()
	{
		base.OnEnable();

		this._sPlanetView = this.target as PlanetView;
	}
}
#endif