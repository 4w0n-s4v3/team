using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Questlist : MonoBehaviour
{
    [Header("# UI Controller")]
    public UIControl uiControl;

    

#if UNITY_EDITOR
    public void OnValidate()
    {

    }
#endif

    virtual public void Awake()
    {

    }

    virtual public void OnEnable()
    {
        Debug.Log("Enable");
    }

    virtual public void Update()
    {
        
    }

}