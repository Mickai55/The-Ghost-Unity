using UnityEngine;
using UnityEngine.UI;

public class dashes : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        if (transform.name == "Dash1")
            GetComponent<Slider>().value = Dash.dash1 / Dash.dashRate;
        if (transform.name == "Dash2")
            GetComponent<Slider>().value = Dash.dash2 / Dash.dashRate;
    }
}