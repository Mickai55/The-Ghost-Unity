using UnityEngine;

public class DoorMove : MonoBehaviour
{
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    [SerializeField] private GameObject coin;
    private bool sw = false;
    private AudioSource sound;

    // Start is called before the first frame update
    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (coin.GetComponent<MeshCollider>().enabled == false)
        {
            if (sw == false)
            {
                sound.Play(0);
                sw = true;
            }
            moveLeft(p1);
            moveRight(p2);
        }
    }

    private void moveLeft(GameObject p)
    {
        if (p.transform.localPosition.z < 1.53f)
            p.transform.localPosition += new Vector3(0, 0, 0.001f);
    }

    private void moveRight(GameObject p)
    {
        if (p.transform.localPosition.z > -1.51f)
            p.transform.localPosition -= new Vector3(0, 0, 0.001f);
    }
}