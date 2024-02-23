using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explsoionParticle;
    public int pointValue;
    private Rigidbody targetRb;
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    private float yRangePos = -6.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        //capture the rigidbody
        targetRb = GetComponent<Rigidbody>();
        // give the rigidbody fandom force
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        // rotate the traget with a random rotation on each axis
        targetRb.AddTorque(RandomTorque(),
            RandomTorque(),
            RandomTorque(),
            ForceMode.Impulse);
        //set the position of the target to a random position
        transform.position = RandomSpawnPos();
       
    }


   
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), yRangePos, 0);
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
        GameManage.instance.UpdateScore(pointValue);
        Instantiate(explsoionParticle, transform.position, explsoionParticle.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
