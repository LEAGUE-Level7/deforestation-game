using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenToMenu : MonoBehaviour
{
    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Returning To The Menu");
    }
}


