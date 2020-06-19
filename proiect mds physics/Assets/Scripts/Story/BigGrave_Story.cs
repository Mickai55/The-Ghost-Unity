using UnityEngine;
using UnityEngine.SceneManagement;

public class BigGrave_Story : MonoBehaviour
{
    // Start is called before the first frame update

    private void Interact()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GetComponent<SceneTransition>().FadeIn("Mesaj de trecere in nefiinta");
    }

    // Update is called once per frame
}