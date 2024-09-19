using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] GameObject rotationObject;
    [SerializeField] float Speed;
    private void OnEnable()
    {
        rotationObject = GameObject.Find("RotationObject");

        Speed = rotationObject.GetComponent<RotationObject>().Speed;

        transform.localRotation = rotationObject.transform.localRotation;
    }
    private void Update()
    {
        transform.Rotate(0, Speed * Time.deltaTime, 0);
    }
}
