using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DontDestoryObject : MonoBehaviour
{
    private static List<string> dontDistroyObjects = new List<string>();

    void Awake()
    {
        if (dontDistroyObjects.Contains(gameObject.name))
        {
            Destroy(gameObject);
            return;
        }
        
        dontDistroyObjects.Add(gameObject.name);
        DontDestroyOnLoad(gameObject);
    }
}
