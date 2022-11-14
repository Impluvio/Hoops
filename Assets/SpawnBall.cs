using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [Tooltip("Add Ball Prefab Here")]
    [SerializeField] GameObject ball; 
    [Tooltip("Add Spawner here")]
    [SerializeField] Transform spawnPoint; // add spawn point here


    // Start is called before the first frame update
    
    public void CreateBall()
    {
        Instantiate(ball, spawnPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
