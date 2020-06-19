using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private float speed;

    private string messageScreen;

    private enum TransitioningPhases
    { off, transitioningPanel, transitioningTextAppearing };

    private TransitioningPhases transitioningPhase;

    private float alfa = 0;

    private void Start()
    {
        transitioningPhase = TransitioningPhases.off;
    }

    private void Update()
    {
        if (transitioningPhase == TransitioningPhases.transitioningPanel)
        {
            panel.GetComponent<Image>().color = new Color(0, 0, 0, alfa);
            alfa += Time.deltaTime * speed;
            if (alfa >= 1)
            {
                transitioningPhase = TransitioningPhases.transitioningTextAppearing;
                alfa = 0;
                panel.transform.GetChild(0).GetComponent<Text>().text = messageScreen;
            }
        }
        else if (transitioningPhase == TransitioningPhases.transitioningTextAppearing)
        {
            panel.transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, alfa);
            alfa += Time.deltaTime * speed;
        }
    }

    public void FadeIn(string message)
    {
        messageScreen = message;
        transitioningPhase = TransitioningPhases.transitioningPanel;
        Invoke("LaunchNextScene", 1 / speed + 2.5f);
    }

    private void LaunchNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}