using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCollision : MonoBehaviour
{
    [SerializeField] private string strTag;
    private MeshCollider c;

    private void Start()
    {
        c = GetComponent<MeshCollider>();
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    // 	if(collision.collider.tag == strTag)
    // 		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // 	else
    // 		Physics.IgnoreCollision(collision.collider, c);
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(strTag))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}