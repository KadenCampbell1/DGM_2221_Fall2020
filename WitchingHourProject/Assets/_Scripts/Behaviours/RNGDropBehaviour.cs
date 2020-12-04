using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNGDropBehaviour : MonoBehaviour
{
    public List<GameObject> list;
    public float chanceOneMin, chanceOneMax, chanceTwoMin, chanceTwoMax, chanceThreeMin, chanceThreeMax;
    private int i;

    public void RollRNG()
    {
        i = Random.Range(0, 100);
        if (i >= chanceOneMin && i <= chanceOneMax)
        {
            Instantiate(list[0], transform.position, transform.rotation);
        }
        if (i >= chanceTwoMin && i <= chanceTwoMax)
        {
            Instantiate(list[1], transform.position, transform.rotation);
        }
        if (i >= chanceThreeMin && i <= chanceThreeMax)
        {
            Instantiate(list[2], transform.position, transform.rotation);
        }
    }
}
