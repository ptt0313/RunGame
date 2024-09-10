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
        Vector3 vector3 = new Vector3(positionX * (int)line, 0, 0);
        rigidbody.MovePosition(vector3);
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
