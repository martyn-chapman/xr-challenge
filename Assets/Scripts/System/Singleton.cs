using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;


    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogWarning("Could not find instance of " + typeof(T));
            }

            return _instance;
        }
    }


    /// <summary>
    /// As this Awake() function is used to assign a value to this instance, this function's behaviour should not be overriden in derived classes. Instead override virtual function Init()
    /// </summary>
    protected void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogError("More than 1 instance of " + typeof(T) + " found in GameObject " + gameObject.name + ". " + typeof(T) + " is a singleton and only 1 instance is allowed.");
        }
        _instance = this as T;

        Init();
    }


    /// <summary>
    /// Null the current instance if this object is destroyed.
    /// </summary>
    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }


    /// <summary>
    /// Creates a Debug.Log showing if this singleton instance is null or not.
    /// </summary>
    protected void CheckValid()
    {
        if (_instance == null)
            Debug.LogWarning("Could not find instance of " + typeof(T));
        else
            Debug.Log("Instance of " + typeof(T) + " found!");
    }


    /// <summary>
    ///  As behaviour for Awake() is defined in Singleton.cs class and should not be overriden in derived classes of Singleton.cs, use Init() for anything that would normally be called in Awake()
    /// </summary>
    protected virtual void Init() { }
}
