using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bullet;
    private GameObject spawnedBullet;
    private float timeAfterShot = 0;
    [SerializeField] private float shootingRate = 0.2f;
    [SerializeField] private bool isAutomatic = false;
    private ParticleSystem particleShoot;
    private CameraMouse mainCamera;
    [SerializeField] private float howShaky = 5;
    [SerializeField] private float recoil = 5;
    private float recoilVar = 0;
    private AudioSource pistolShot;
    private AudioSource pistolDrop;
    public static AudioSource pistolPickup;

    private void Start()
    {
        particleShoot = transform.GetChild(transform.childCount - 1).GetComponent<ParticleSystem>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        pistolShot = audioSources[0];
        pistolDrop = audioSources[1];
        pistolPickup = audioSources[2];
        mainCamera = GameObject.Find("Main Camera").GetComponent<CameraMouse>();
    }

    private void Update()
    {
        Shooting();
        Recoil();
        ThrowingWeapon();
    }

    private void Recoil()
    {
        mainCamera.cameraShake /= 1.2f;
        if (recoilVar >= 0.1)
        {
            if (gameObject.name == "PISTOL")
                transform.localRotation = Quaternion.Euler(WeaponPickup.pistolRot.x - recoilVar, WeaponPickup.pistolRot.y, WeaponPickup.pistolRot.z);
            if (gameObject.name == "AKau")
                transform.localRotation = Quaternion.Euler(WeaponPickup.akRot.x - recoilVar, WeaponPickup.akRot.y, WeaponPickup.akRot.z);
        }
        recoilVar /= 1.1f;
    }

    public void Shooting()
    {
        if (!isAutomatic)
        {
            if (Input.GetMouseButtonDown(0) && gameObject.transform.parent != null && Time.time - timeAfterShot > shootingRate)
            {
                PressToShoot();
            }
        }
        else if (Input.GetMouseButton(0) && gameObject.transform.parent != null && Time.time - timeAfterShot > shootingRate)
        {
            PressToShoot();
        }
    }

    private void PressToShoot()
    {
        //pistolShot.pitch = Random.Range(0.95f, 1.05f);
        SoundManager.PlayCustom(pistolShot);

        particleShoot.Play();
        mainCamera.cameraShake += howShaky;
        recoilVar = recoil;

        // daca se misca caracteru aiurea in vreo directie aici
        spawnedBullet = Instantiate(bullet, transform.GetChild(0).transform.position + transform.forward * 0.25f -
                                transform.up * 0.1f + transform.right * 0.1f, Quaternion.Euler(Vector3.forward));

        spawnedBullet.GetComponent<Rigidbody>().velocity += (transform.parent.transform.forward - 0.01f * transform.parent.transform.right
                                                        + 0.01f * transform.parent.transform.up) * speed + Vector3.right * Random.Range(-10f, 10f) + Vector3.up * Random.Range(-8f, 8f);

        timeAfterShot = Time.time;
    }

    public void ThrowingWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Q) && gameObject.transform.parent != null)
        {
            gameObject.transform.parent = null;
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().mass = 0.05f;
            gameObject.GetComponent<Rigidbody>().velocity += transform.forward * 30;
            float rand = Random.Range(10, 40);
            transform.Rotate(transform.right * rand);
        }

        if (gameObject.transform.parent == null && gameObject.GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        try{
            if (transform.parent.name != null)
                pistolDrop.Play(0);
        }
        catch{}
    }
}