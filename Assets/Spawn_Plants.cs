using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Plants : MonoBehaviour
{

    public GameObject Plants;
  
   
    // Start is called before the first frame update
    
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            Vector3 location_rand = Vector3.one * 100;


            location_rand.y = 0;
            location_rand.z *= Random.value;
            location_rand.x *= Random.value;
          
            Instantiate(Plants, location_rand, Quaternion.identity);
          
        }

    }
}
