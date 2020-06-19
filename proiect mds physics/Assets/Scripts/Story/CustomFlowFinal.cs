using UnityEngine;

public class CustomFlowFinal : MonoBehaviour
{
    private Light directionalLight;

    // Start is called before the first frame update
    private void Start()
    {
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (directionalLight.intensity <= 1.3f)
            directionalLight.intensity += Time.deltaTime * 0.1f;
    }
}