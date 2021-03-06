﻿/* Created by Luna.Ticode */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;
#endif

using TMPro;

public class MonoBehaviourSingleton<T> : MonoBehaviour
    where T : MonoBehaviourSingleton<T>
{
    private static T s_instance;
    public static T Instance_ { get { return s_instance; } }

    protected virtual void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this as T;

            Transform activeTransform = this.transform;
            while (activeTransform.parent != null)
            {
                activeTransform = activeTransform.parent;
            }

            Object.DontDestroyOnLoad(activeTransform.gameObject);
        }
        else if (s_instance != this)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
