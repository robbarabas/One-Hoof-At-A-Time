using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is where i want to hold the genetic data 


public class test_tranfer : MonoBehaviour
{
    
    public float speed;
    public float vision_size;
    public float body_size;
    public float hunger;
    public float camo;//chanse to be seen not implemented
    public int Food = 0;
    

    public void pop()
        //test function 
    {
        Food++;
    }
    public float get_speed()
    {
        return speed;
    }
    public float get_vision_size()
    {
        return vision_size;
    }
    public float get_body_size()
    {
        return body_size;
    }
    public float get_camo()
    {
        return camo;
    }
    public void set_genome(float[] V)
    {
        speed = V[0];
        vision_size = V[1];
        body_size= V[2];
        hunger = V[3];
        camo = V[4];

    }
}
