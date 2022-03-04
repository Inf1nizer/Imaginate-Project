using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamehasEnded = false;
    public void EndGame()
    {
        if(gamehasEnded == false)
        {
            gamehasEnded = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }        
    }
}
