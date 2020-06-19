using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelInteraction : MonoBehaviour
{
    public void Interact()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}