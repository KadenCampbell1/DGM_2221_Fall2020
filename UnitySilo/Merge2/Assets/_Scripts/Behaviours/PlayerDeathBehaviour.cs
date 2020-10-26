using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathBehaviour : MonoBehaviour
{
    public FloatData objHealth, respawnHealth;
    public IntData playerLives;
    public Vector3Data spawnLocation;
    public GameObject objForDeath;
    public float waitTime = 3f;

    private void Update()
    {
        if (objHealth.value <= 0)
        {
            objForDeath.gameObject.SetActive(false);
            playerLives.value--;
            if (playerLives.value > 0)
            {
                objForDeath.gameObject.transform.position = spawnLocation.value;
                objHealth.value = respawnHealth.value;
                StartCoroutine(Wait(waitTime));
            }
            if (playerLives.value <= 0)
            {
                Debug.Log("GameOver");
                playerLives.value = 0;
            }
        }
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        objForDeath.gameObject.SetActive(true);
    }
}
