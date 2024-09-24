using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinCache : MonoBehaviour
{
    static readonly Dictionary<float, WaitForSeconds> dictionary = new Dictionary<float, WaitForSeconds>(new Compare());

    class Compare : IEqualityComparer<float>
    {
        public bool Equals(float x, float y)
        {
            return x == y;
        }

        public int GetHashCode(float hash)
        {
            return hash.GetHashCode();
        }
    }
    public static WaitForSeconds waitForSecond(float time)
    {
        
        if (dictionary.TryGetValue(time,out WaitForSeconds waitForSeconds) == false)
        {
            dictionary.Add(time,new WaitForSeconds(time));

            return waitForSeconds;
        }
        else
        {
            return dictionary[time];
        }
        
    }
}
