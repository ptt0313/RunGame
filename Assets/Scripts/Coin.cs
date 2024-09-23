using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IColliderable
{
    [SerializeField] GameObject rotationObject;
    [SerializeField] float Speed;
    [SerializeField] ParticleSystem particleSystem;

    public void Activate()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        particleSystem.Play();
    }

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
