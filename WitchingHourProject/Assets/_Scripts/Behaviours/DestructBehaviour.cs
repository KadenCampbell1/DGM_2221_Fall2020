using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructBehaviour : MonoBehaviour
{
    public bool canDestroyOnStart;
    public float waitTime = 5f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);

        if (canDestroyOnStart)
        {
            Destroy(gameObject);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
