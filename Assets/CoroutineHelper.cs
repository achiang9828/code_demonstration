using System;
using System.Collections;
using UnityEngine;

public class CoroutineHelper : MonoBehaviour
{
    private static CoroutineHelper _instance = null;
    public static CoroutineHelper Instance
    {
        get
        { 
            if (_instance == null)
            {
                Debug.LogError ("Please set up instance in your scene.");
            }
            return _instance;
        }
    }

    void Awake ()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null)
        {
            Destroy (gameObject);
        }
        DontDestroyOnLoad (gameObject);
    }

    public Coroutine Invoke (IEnumerator function)
    {
        return StartCoroutine (function);
    }

    public Coroutine Invoke (float delay, Action function)
    {
        return StartCoroutine (RunInvoke (delay, function));
    }

    public Coroutine InvokeAfterOneFrame (Action function)
    {
        return StartCoroutine (RunInvokeAfterOneFrame (function));
    }

    public void CancelInvoke (Coroutine coroutine)
    {
        StopCoroutine (coroutine);
    }

    IEnumerator RunInvoke (float delay, Action function)
    {
        yield return new WaitForSeconds (delay);
        function.Invoke ();
    }

    IEnumerator RunInvokeAfterOneFrame (Action function)
    {
        yield return null;
        function.Invoke ();
    }
}
