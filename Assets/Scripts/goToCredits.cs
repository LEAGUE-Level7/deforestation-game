using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToCredits : MonoBehaviour
{
    public void toCredits()
    {
        SceneManager.LoadScene(3);
        Debug.Log("Going to credits");
    }
}
