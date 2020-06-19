using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    private void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.LookAt(target.transform.position);
        //transform.rotation = Quaternion.Euler(Vector3.RotateTowards(transform.rotation.ToEulerAngles(), target.transform.position,5, 1 ));
        //Quaternion.LookRotation(Quaternion.RotateTowards(transform.localRotation,))
        transform.rotation =  Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(target.transform.position.x,0,target.transform.position.z) - transform.position), 360f);


    }
}