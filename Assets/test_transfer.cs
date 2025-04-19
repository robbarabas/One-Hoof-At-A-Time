using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is where i want to hold the genetic data 


public class test_transfer : MonoBehaviour
{
    public float destroy_time;
    public int ID;
    public float speed;
    public float vision_size;
    public float body_size;
    public float hunger;
    public float camo;//chanse to be seen not implemented
    public int Food = 0;
    float Time_start;

    
    void Start()
    {
        // destroy_time =Animal_Spawner.destory_time;
        Time_start = Time.time;
        var cubeRenderer =GetComponent<Renderer>();

        // Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        transform.localScale = Vector3.one * body_size;
    }
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
    public float get_food()
    {
        return Food;
    }
    public void set_genome(float _speed,float _vision, float _size , float _hunger , float _camo,int _ID)
    {
        speed =0.5f+ _speed*3;
        vision_size =(_vision)*5+_size;
        body_size=0.5f +_size;
        hunger =_hunger;
        camo = _camo;
        ID = _ID;
    }
    

    void Update()
    {

        if (Time.time > destroy_time+Time_start) { Destroy(this.gameObject); }

    }

}
