using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float _selfRotationSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;

    [SerializeField] private Transform _star;

    private void RotateSelf()
    {
        this.transform.Rotate(Vector3.up * this._selfRotationSpeed, Space.Self);
    }

    public void RotateAround(Transform transform)
    {
        this.transform.RotateAround(transform.position, Vector3.up, this._rotationSpeed);
    }

    private void Update()
    {
        //this.RotateSelf();
        this.RotateAround(this._star);
    }
}
