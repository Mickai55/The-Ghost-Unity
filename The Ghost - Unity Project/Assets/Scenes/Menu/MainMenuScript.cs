using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityScript.Lang;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject panelOptions,panelMainMenu,panelLevels;
    private void Start()
    {
       
 
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickOptions()
    {
        panelMainMenu.SetActive(false);
        panelOptions.SetActive(true);
    }
    public void OnClickNewGame()
    {
        panelMainMenu.SetActive(false);
        panelLevels.SetActive(true);

        GameObject[] buttonsGameObjects;
        int levelsPlayed = PlayerPrefs.GetInt("LevelsPlayed", 0);

        buttonsGameObjects = GameObject.FindGameObjectsWithTag("Button Level");
        for (int i = levelsPlayed + 1; i < buttonsGameObjects.Length; i++)
        {
            //buttonsLevels.Add(button.GetComponent<Button>());
            buttonsGameObjects[i].SetActive(false);
        }
    }
    public void OnClickBackOptions()
    {
        panelOptions.SetActive(false);
        panelMainMenu.SetActive(true);
    }
    public void OnClickBackLevels()
    {
        panelLevels.SetActive(false);
        panelMainMenu.SetActive(true);
    }
    public void OnClickStartLevel(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void OnClickDeleteProgress()
    {
        PlayerPrefs.SetInt("LevelsPlayed",0);
    }
}
