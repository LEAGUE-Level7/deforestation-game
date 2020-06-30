using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject menu;


    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Ran");
            revealMenu();
        }
    }


    private void revealMenu()
    {
        if (menu != null) 
            menu.SetActive(!menu.activeSelf);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);

    }




}
