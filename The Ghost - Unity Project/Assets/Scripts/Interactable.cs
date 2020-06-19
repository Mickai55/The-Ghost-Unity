using UnityEngine;

public class Interactable : MonoBehaviour
{
    private GameObject interactAvaibleMessage;

    private BoxCollider bc;

    private void Start()
    {
        interactAvaibleMessage.SetActive(false);
    }

    private void Awake()
    {
        interactAvaibleMessage = GameObject.Find("Interact");
        bc = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        bc.size += Vector3.one * 2;
        bc.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                BroadcastMessage("Interact");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            interactAvaibleMessage.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            interactAvaibleMessage.SetActive(false);
    }
}