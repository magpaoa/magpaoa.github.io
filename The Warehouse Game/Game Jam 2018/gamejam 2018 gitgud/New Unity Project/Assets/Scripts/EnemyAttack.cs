using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float maxDamage = 75f;
    public float minDamage = 25f;
    public AudioSource ghostScream;
    public float flashIntensity = 3f;
    public float fadeSpeed = 10f;

    private Animator anim;
    private HashIDs hash;
    private LineRenderer crazyEyeLine;
    private Light crazyEyeLight;
    private SphereCollider col;
    private Transform player;
    private PlayerHealth playerHealth;
    private bool screaming;
    private float scaleDamage;


    void Awake()
    {
        anim = GetComponent<Animator>();
        crazyEyeLine = GetComponentInChildren<LineRenderer>();
        crazyEyeLight = crazyEyeLine.GetComponent<Light>();
        col = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("player").transform;
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        hash = GameObject.FindGameObjectWithTag("MainControl").GetComponent<HashIDs>();
        crazyEyeLine.enabled = false;
        crazyEyeLight.intensity = 0f;

        scaleDamage = maxDamage - minDamage;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float shout = anim.GetFloat(hash.shoutFloat);
        if (shout > 0.5f && !screaming)
            Scream();
        if(shout < 0.5f)
        {
            screaming = false;
            crazyEyeLight.enabled = false;
        }

        crazyEyeLight.intensity = Mathf.Lerp(crazyEyeLight.intensity, 0f, fadeSpeed * Time.deltaTime);
	}

    void Scream()
    {
        screaming = true;
        float fractionalDistance = (col.radius - Vector3.Distance(transform.position, player.position)) / col.radius;
        float damage = scaleDamage * fractionalDistance + minDamage;
        playerHealth.TakeDamage(damage);
    }
}
