using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTrigger : MonoBehaviour
{

    // Update is called once per frame
 
    public Color defaultColor = Color.white;
    void OnTriggerEnter(Collider other) 
    {
        Renderer render = GetComponent<Renderer>();

        defaultColor = render.material.color;
        render.material.color = Color.red;
    }

    private void OnTriggerExit(Collider other)
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = defaultColor;
    }
}
