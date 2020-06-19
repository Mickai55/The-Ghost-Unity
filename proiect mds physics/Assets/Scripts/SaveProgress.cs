using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveProgress : MonoBehaviour
{
    private void Start()
    {
        int levelsPlayed = PlayerPrefs.GetInt("LevelsPlayed", 0);
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        print(levelsPlayed);
        print(currentLevel);
        if (currentLevel > levelsPlayed)
            PlayerPrefs.SetInt("LevelsPlayed", currentLevel);
    }
}