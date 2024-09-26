using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : State, IColliderable
{
    [SerializeField] GameObject rotationObject;
    [SerializeField] float Speed;

    public void Activate()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnEnable()
    {
        base.OnEnable();

        rotationObject = GameObject.Find("RotationObject");

        Speed = rotationObject.GetComponent<RotationObject>().Speed;

        transform.localRotation = rotationObject.transform.localRotation;
    }
    private void Update()
    {
        if (state == false) return;
        transform.Rotate(0, Speed * Time.deltaTime, 0);
    }

}
