using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField] ResourceLogic rLogic;

    // Start is called before the first frame update
    public void StartGame()
    {
        rLogic = new ResourceLogic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        rLogic.resetValues();
        Debug.Log("Game Started" + SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    
     public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
        Debug.Log("Quit Game");
#endif     
    }
}
