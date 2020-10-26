using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathBehaviour : MonoBehaviour
{
    public float objHealth, respawnHealth;
    public int playerLives;
    public Vector3Data spawnLocation;
    public GameObject objForDeath;
    public float waitTime = 3f;

    public void UpdateHealth()
    {
        objHealth -= 5;
    }

    private void Update()
    {
        if (objHealth <= 0)
        {
            objForDeath.gameObject.SetActive(false);
            playerLives--;
            if (playerLives > 0)
            {
                objForDeath.gameObject.transform.position = spawnLocation.value;
                objHealth = respawnHealth;
                StartCoroutine(Wait(waitTime));
            }
            if (playerLives <= 0)
            {
                Debug.Log("GameOver");
                playerLives = 0;
            }
        }
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        objForDeath.gameObject.SetActive(true);
    }
}
