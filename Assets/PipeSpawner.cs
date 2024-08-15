using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    //public float spawnRateDecrease = 0.005f;
    //public float minSpawnRate = 0.5f; 
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime; 
        }
        else
        {
            spawnPipe();
            timer = 0; 
        }
        //spawnRate -= spawnRateDecrease * Time.deltaTime;
        //spawnRate = Mathf.Max(spawnRate, minSpawnRate); 
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(25, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
