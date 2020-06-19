using UnityEngine;
using UnityEngine.UI;

public class FinalScript : MonoBehaviour
{
    private Text castText;
    private bool isEnding = false;

    // Start is called before the first frame update
    private void Start()
    {
        castText = GameObject.Find("FinalText").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isEnding)
            castText.rectTransform.transform.Translate(Vector3.up);
    }

    public void DisableThings()
    {
        GetComponent<PlayerMovement>().enabled = false;
        transform.GetChild(0).GetComponent<CameraLook>().enabled = false;
        isEnding = true;
    }
}