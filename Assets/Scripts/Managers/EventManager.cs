using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public enum EventType
{
    START,
    CONTINUE,
    PAUSE,
    STOP
}
public static class EventManager
{
    static readonly IDictionary<EventType,UnityEvent> dictionary = new Dictionary<EventType, UnityEvent>();
    public static void Subscribe(EventType eventType, UnityAction unityAction)
    {
        
    }
    public static void UnSubscribe(EventType eventType, UnityAction unityAction)
    {
        
    }
    public static void Publish(EventType eventType)
    {

    }
}
