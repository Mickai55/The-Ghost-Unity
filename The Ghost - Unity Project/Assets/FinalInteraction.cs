using UnityEngine;

public class FinalInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactPanel;

    public void Interact()
    {
        GameObject.Find("Player").GetComponent<FinalScript>().DisableThings();
        GameObject.Find("Player").GetComponent<Animator>().enabled = true;
        Destroy(interactPanel);
    }
}