using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Main : MonoBehaviour
{
    private readonly Type[] singletonsToLoad =
    {};
    public static Main instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<Main>();

            if (_instance == null)
                Debug.LogError("We can't find the singleton instance of MAIN in this scene. (You need maint populate the rest of your singleton instances)");

            if (!initialized && initializationState != InitializationState.Initializing)
                instance.Initialize();

            return _instance;
        }
    }
    private static Main _instance;
    private static InitializationState initializationState = InitializationState.Uninitialized;
    public static bool initialized => initializationState == InitializationState.Initialized;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        initializationState = InitializationState.Initializing;

        foreach(System.Type singleton in singletonsToLoad)
        {
            if (FindObjectOfType(singleton) == null)
            {
                Transform child = new GameObject().transform;
                child.SetParent(transform);
                child.name = singleton.ToString();
                child.gameObject.AddComponent(singleton);
            }
            yield return new WaitForEndOfFrame();
        }

        initializationState = InitializationState.Initialized;
    }
}

public enum InitializationState
{
    Uninitialized,
    Initializing,
    Initialized
}