//using NUnit.Framework;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // Start is called before the first frame update
    public enum EnemyState
    {
        Idle,
        Attacking,
        Chasing,
        Death
    }

    private const float ROTATION_SPEED = 100f;
    private GameObject player;

    //GameObject enemy;
    [SerializeField] private float visionRange;
    [SerializeField] bool infiniteVision = false;
    [SerializeField] private float attackingRange;
    [SerializeField] private float shootingCooldown;
    [SerializeField] private float speed;
    [SerializeField] private float fieldOfView = 360;
    [SerializeField] private float health = 100;
    [SerializeField] private EnemyState currentState;
    [SerializeField] private float damage;
    private float initSpeed;
    private bool playerInSight;
    private SphereCollider visionColidier;
    private Vector3 lastPlayerSeenPosition;
    [SerializeField] private AudioClip hitClip;

    private void Start()
    {
        initSpeed = speed;

        player = GameObject.Find("Player");
        //player = player.GetComponentInChildren<CapsuleCollider>().gameObject;
        if (player == null)
        {
            Debug.Log("player not found");
        };
        visionColidier = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        //print(currentState);
        switch (currentState)
        {
            case EnemyState.Idle:
                //check if player in range
                if (playerInSight)
                {
                    currentState = EnemyState.Chasing;
                }
                break;

            case EnemyState.Attacking:
                if (playerInSight)
                {
                    if (!IsPlayerInAttackingRange())
                        currentState = EnemyState.Chasing;
                }

                break;

            case EnemyState.Chasing:
                if (playerInSight)
                {
                    if (IsPlayerInAttackingRange())
                        currentState = EnemyState.Attacking;
                    else
                    {
                        MoveTowardsPlayer();
                    }
                }
                else
                {
                    if (Vector3.Distance(lastPlayerSeenPosition, transform.position) < 5)
                        currentState = EnemyState.Idle;
                    else
                    {
                        MoveTowardsPlayer();
                    }
                }
                break;

            case EnemyState.Death:
                this.gameObject.SetActive(false);
                break;

            default:
                break;
        }
    }

    private void MoveTowardsPlayer()
    {
        if (lastPlayerSeenPosition == Vector3.zero)
            return;
        Vector3 direction = lastPlayerSeenPosition - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), ROTATION_SPEED);

        //  Quaternion rotation = Quaternion.LookRotation(direction);
        //  transform.rotation = Quaternion.Lerp(transform.rotation, rotation, ROTATION_SPEED * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, lastPlayerSeenPosition, speed * Time.deltaTime);
        //transform.Translate(Vector3.forward * Time.deltaTime);
        Debug.DrawRay(transform.position, lastPlayerSeenPosition);
    }

    private bool IsPlayerInVisionRange()
    {
        return Vector3.Distance(player.transform.position, gameObject.transform.position) < visionRange;
    }

    private bool IsPlayerInAttackingRange()
    {
        return Vector3.Distance(player.transform.position, gameObject.transform.position) < attackingRange;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerDestroyable>().GetHit(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerDestroyable>().GetHit(damage * 20);
            GetComponent<AudioSource>().PlayOneShot(hitClip, 0.2f);
            speed = 2;
        }
    }

    private void OnCollisionExit()
    {
        speed = initSpeed;
    }

    //Detect perspective field of view for the AI Character

    private void OnTriggerStay(Collider other)
    {
        //print("trigger");
        if(infiniteVision)
        lastPlayerSeenPosition = player.transform.position;

        if (other.gameObject == player)
        {
            //print("hit player");
            playerInSight = false;
            Vector3 direction = other.transform.position - transform.position;
            Debug.DrawRay(transform.position + transform.up, direction.normalized * visionColidier.radius, Color.green);

            float angle = Vector3.Angle(direction, transform.forward);
            if (angle < fieldOfView * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, visionColidier.radius))
                {
                    //print("angle");
                    playerInSight = true;

                    if (hit.collider.gameObject == player)
                    {
                        //print("player in range");
                        lastPlayerSeenPosition = player.transform.position;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInSight = false;
        }
    }

    public void FocusPlayer()
    {
        transform.LookAt(GameObject.Find("Player").transform.position);
    }
}