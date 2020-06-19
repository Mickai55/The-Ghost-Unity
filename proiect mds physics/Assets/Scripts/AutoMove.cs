using UnityEngine;

public class AutoMove : MonoBehaviour
{
    private enum RepeatType
    { noRepeat, RepeatBomerang, normalRepeat };

    private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private RepeatType repeatType;
    [SerializeField] private float time;
    [SerializeField] private float startDelay;
    [SerializeField] private float maxDistance;

    private bool started;
    private Vector3 initPos;

    private void Start()
    {
        started = false;
        if (repeatType != RepeatType.noRepeat)
            initPos = transform.position;
        Invoke("StartMove", startDelay);
        player = GameObject.Find("Player");
    }

    private void StartMove()
    {
        started = true;
        if (repeatType == RepeatType.noRepeat)
            Invoke("Stop", time);
        if (repeatType == RepeatType.RepeatBomerang)
            Invoke("InvertDirection", time);
        else if (repeatType == RepeatType.normalRepeat)
            Invoke("Repeat", time);
    }

    private void Stop()
    {
        enabled = false;
    }

    private void Repeat()
    {
        transform.position = initPos;
        Invoke("Repeat", time);
    }

    private void InvertDirection()
    {
        direction *= -1;
        Invoke("InvertDirection", time);
    }

    // Update is called once per frame
    private void Update()
    {
        if (started && Vector3.Distance(player.transform.position, transform.position) <= maxDistance)
            transform.Translate(direction * speed * Time.deltaTime);
    }
}