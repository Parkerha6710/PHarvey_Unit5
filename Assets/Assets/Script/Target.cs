using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float minForce = 10;
    private const float maxForce = 15;
    private const float minTorque = -10;
    private const float maxTorque = 10;
    private const float minXPos = -3;
    private const float maxXPos = 3;
    private const float ySpawnPos = -2;
   
    public int points;
    public ParticleSystem boom;
    GameManager gameManager;
    

    private Rigidbody targetRB;
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        RandomForce();
        RandomTorque();
        RandomSpawnPos();
    }

    void RandomForce()
    {
        targetRB.AddForce(Vector3.up * Random.Range(minForce, maxForce),
            ForceMode.Impulse);
    }

    void RandomTorque()
    {
        targetRB.AddTorque(Random.Range(minTorque, maxTorque),
            Random.Range(minTorque, maxTorque),
            Random.Range(minTorque, maxTorque), ForceMode.Impulse);
    }

    void RandomSpawnPos()
    {
        transform.position = new Vector3(Random.Range(minXPos, maxXPos), ySpawnPos);
    }

    private void OnMouseDown()
    {
        gameManager.UpdateScore(points);
        Destroy(gameObject);
        Instantiate(boom, transform.position, boom.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }
}