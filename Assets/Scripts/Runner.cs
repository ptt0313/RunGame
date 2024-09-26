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

public class Runner : State
{
    [SerializeField] RoadLine line;
    Rigidbody rigidbody;
    [SerializeField] float positionX = 4.0f;
    [SerializeField] float speed = 25.0f;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        base.OnEnable();
        InputManager.Instance.action += OnKeyUpdate;
    }
    void Start()
    {
        line = RoadLine.MIDDLE;
    }
    void OnKeyUpdate()
    {
        if (state == false) return;
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.Publish(EventType.STOP);
        }
    }
    void Move()
    {
        rigidbody.position = Vector3.Lerp(rigidbody.position, new Vector3(positionX * (int)line, 0, 0), speed * Time.fixedDeltaTime);
    }
    void FixedUpdate()
    {
        if (state == false) return;
        Move();
    }
    private void OnDisable()
    {
        base.OnDisable();
        InputManager.Instance.action -= OnKeyUpdate;
    }

    private void OnTriggerEnter(Collider other)
    {
        //IColliderable colliderable = other.GetComponent<IColliderable>();
        //if(colliderable != null)
        //{
        //    colliderable.Activate();
        //}
        other.gameObject.GetComponent<IColliderable>()?.Activate();
    }
}
