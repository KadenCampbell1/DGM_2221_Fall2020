using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value;

    public void IncrementValue(float obj)
    {
        value += obj;
    }
}
