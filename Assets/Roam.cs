using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roam : MonoBehaviour
{
    public Vector3 Rand = Vector3.zero;
    float value_random = 0;
    public float speed = 3;
    int sign_x=1, sign_z=1;
    
    // Start is called before the first frame update
    void Start()
    {


        value_random = Random.value;
      
        if (Random.value > 0.5) sign_z = -1;else sign_z = 1;
        if (Random.value > 0.5) sign_x = -1; else sign_x = 1;
        Rand.x = (1 - value_random)*sign_x;
        Rand.z = value_random*sign_z;
    }

    // Update is called once per frame
    void Update()
    {

        if (Rand.x  + transform.position.x > -4 && Rand.x + transform.position.x < 4 && Rand.z + transform.position.z > -4 && Rand.z  + transform.position.z < 4)
            transform.position += Rand *  speed * Time.deltaTime;
        else
        {
            value_random = Random.value;

            if (Random.value > 0.5) sign_z = -1; else sign_z = 1;
            if (Random.value > 0.5) sign_x = -1; else sign_x = 1;
            Rand.x = (1 - value_random) * sign_x;
            Rand.z = value_random * sign_z;
            transform.position +=  (Rand * value_random * speed * Time.deltaTime);
        }
        
    }
  
   

}
