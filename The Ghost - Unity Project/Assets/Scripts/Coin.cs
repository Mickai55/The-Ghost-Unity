using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource sound;

    // Start is called before the first frame update
    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += 2;
        transform.localRotation = Quaternion.Euler(rotationVector);
    }

    private void OnCollisionEnter(Collision collision)
    {
        sound.Play(0);
        // SleepTimeout(0.1f);
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<Light>().enabled = false;
    }
}