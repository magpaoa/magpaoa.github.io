using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;

    private UnityEngine.AI.NavMeshAgent nav;
    private SphereCollider col;
    private Animator anim;
    private Vector3 intialSettings;
    private GameObject player;
    private Animator playerAnim;
    private PlayerHealth playerHealth;
    private HashIDs hash;
    private Vector3 previousSighting;
    public Vector3 lastPlayerSighting;


    void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        anim = GetComponent<Animator>();
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
        hash = GameObject.FindGameObjectWithTag("MainControl").GetComponent<HashIDs>();

        personalLastSighting = intialSettings;
        previousSighting = lastPlayerSighting;
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(lastPlayerSighting != previousSighting)
             personalLastSighting = lastPlayerSighting;

        previousSighting = lastPlayerSighting;

        if (playerHealth.health > 0f)
            anim.SetBool(hash.playerInSightBool, playerInSight);
        else
            anim.SetBool(hash.playerInSightBool, false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fieldOfViewAngle *.5f )
            {
                RaycastHit hit;

                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        lastPlayerSighting = player.transform.position;
                    }
                }
            }

            int playerLayerZeroStateHash = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;
            int playerLayerOneStatehash = playerAnim.GetCurrentAnimatorStateInfo(1).fullPathHash;

            if(playerLayerZeroStateHash == hash.locomotionState || playerLayerOneStatehash == hash.shoutState)
            {
                if(CalculatePathLength(player.transform.position) <= col.radius)
                {
                    personalLastSighting = player.transform.position;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            playerInSight = false;
    }

    float CalculatePathLength(Vector3 targetPosition)
    {
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();

        if (nav.enabled)
            nav.CalculatePath(targetPosition, path);

        Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
        allWayPoints[0] = transform.position;
        allWayPoints[allWayPoints.Length - 1] = targetPosition;

        for(int i = 0; i < path.corners.Length; i++)
        {
            allWayPoints[i + 1] = path.corners[i];
        }

        float pathLength = 0f;

        for(int i = 0; i < allWayPoints.Length - 1; i++)
        {
            pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i+1]);
        }

        return pathLength;
    }
}
