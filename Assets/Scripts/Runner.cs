using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1   
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine line;
    Rigidbody rigidbody;
    [SerializeField] float positionX = 2.0f;
    [SerializeField] float speed = 25.0f;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        line = RoadLine.MIDDLE;
    }
    void OnKeyUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(line != RoadLine.LEFT)
            line--;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(line != RoadLine.RIGHT)
            line++;
        }
    }
    void Move()
    {
        rigidbody.position = Vector3.Lerp
            (
                rigidbody.position,
                new Vector3(positionX * (int)line, 0, 0),
                speed * Time.fixedDeltaTime
            );
    }
    void Update()
    {
        OnKeyUpdate();
    }
    void FixedUpdate()
    {
        Move();
    }
}
