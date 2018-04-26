using System.Collections;
using UnityEngine;

public class CoroutineHelperTest : MonoBehaviour
{
    void Start ()
    {
        Tester tester = new Tester ();
        tester.TestInvoke ();
        tester.TestClock ();
    }
}

public class Tester
{
    public void TestInvoke ()
    {
        Coroutine A = CoroutineHelper.Instance.Invoke (1f, Print);
        CoroutineHelper.Instance.Invoke (2f, () =>
        {
            Debug.LogWarning ("Nice to meet you, too!");
        });
    }

    public void TestClock ()
    {
        CoroutineHelper.Instance.Invoke (Clock ());
    }

    void Print ()
    {
        Debug.LogWarning ("Nice to meet you!");
    }

    IEnumerator Clock ()
    {
        int timer = 1;
        while (true)
        {
            Debug.Log (string.Format ("time: {0}", timer));
            timer++;
            yield return new WaitForSeconds (1);
        }
    }
}
