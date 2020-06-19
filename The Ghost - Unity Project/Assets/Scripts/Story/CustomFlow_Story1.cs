using UnityEngine;

public class CustomFlow_Story1 : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject playerLantern;
    [SerializeField] private GameObject citizen;
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject[] postProcessingProfiles = new GameObject[3];
    private Transform player;
    private Light warpLight;
    private AudioSource music;
    private AudioSource ghostSound;

    private bool lanternAquired = false;
    private bool cubeGone = false;

    private enum PPState
    { normal, crazy1, crazy2 };

    private PPState crazyState;

    // Start is called before the first frame update
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        warpLight = GameObject.Find("Directional Light").GetComponent<Light>();
        ghostSound = GameObject.Find("GhostSound").GetComponent<AudioSource>();
        music = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!lanternAquired && cube.GetComponent<Dialog>().currentString == 4)
        {
            playerLantern.SetActive(true);
            lanternAquired = true;
        }
        if (!cubeGone && cube.GetComponent<Dialog>().currentString == 12)
        {
            cubeGone = true;
            ghostSound.Play();
        }
        if (cubeGone)
        {
            cube.transform.Translate(Vector3.forward * Time.deltaTime * -10);
        }
        if (player.position.x < -38 && crazyState == PPState.normal)
        {
            crazyState = PPState.crazy1;
            postProcessingProfiles[0].SetActive(false);  //can be made a function SetPPProfile(index)
            postProcessingProfiles[1].SetActive(true);
            postProcessingProfiles[2].SetActive(false);
        }
        if (player.position.x < -58 && crazyState == PPState.crazy1)
        {
            crazyState = PPState.crazy2;
            postProcessingProfiles[0].SetActive(false);
            postProcessingProfiles[1].SetActive(false);
            postProcessingProfiles[2].SetActive(true);
        }
        if (player.position.x < -64)
        {
            warpLight.intensity += Time.deltaTime * 10;
        }

        // mergea functie care facea sa fie de la 0 la 1, aka normalizare si d-astea

        ghostSound.volume = (1 - Mathf.Abs((-73 - player.position.x - 20) / 100) + 0.1f) / 8;
        ghostSound.pitch = 1 - (1 - Mathf.Abs((-73 - player.position.x - 20) / 100) + 0.1f) / 6;
        music.pitch = 1 + (1 - Mathf.Abs((-73 - player.position.x - 20) / 100) + 0.1f) / 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            citizen.SetActive(false);
            ghost.SetActive(true);
        }
    }
}