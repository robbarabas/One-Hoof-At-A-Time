using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vision : MonoBehaviour
{
   

    public Vector3 Rand = Vector3.zero;

    float value_random = 0;

    public float speed ;

    int sign_x, sign_z;

    public Vector3 Target = Vector3.zero;

    Vector3 direction;

    string Target_name;//Name of the colision element for vision

    public test_transfer Transfer;//test transfer script

    public Collider Curent_Colider;//holds the current vison colider to reset the vision after every succesfull colision with the body
                                   // Start is called before the first frame update
    public Quaternion quaternion;
   public Vector3 Vision_scale ;

    float next_check = 0f;
    float check_time = 0.5f;

    void Start()
    {
        speed = Transfer.get_speed();
        Vision_scale = Vector3.one * Transfer.get_vision_size()/Transfer.get_body_size();
        // asign a random direction 
        value_random = Random.value;

        if (Random.value< 0.5) sign_x = -1; else sign_x = 1;

        if (Random.value < 0.5) sign_z = -1;else sign_z = 1;
        Rand.x = (1 - value_random) *sign_x; ;
        Rand.z = value_random*sign_z ;

        //aplying genome
        transform.localScale = Vision_scale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > next_check)
        {
            next_check = Time.time + check_time;
            reset_vision();
        }
        if (Target == Vector3.zero)//determines if there is a avalable target in vision
        {

            //location condition (Temporary)
            if (Rand.x + transform.parent.position.x > 0 && Rand.x + transform.parent.position.x < 40 && Rand.z + transform.parent.position.z > 0 && Rand.z + transform.parent.position.z < 40)

            {
                transform.parent.position += Rand * speed * Time.deltaTime;
                transform.parent.rotation = Quaternion.Slerp(transform.rotation, quaternion, Time.deltaTime *10f);
            }
            //reshufles direction
            else
            {

                value_random = Random.value;
                if (Random.value < 0.5) sign_x = -1; else sign_x = 1;

                if (Random.value < 0.5) sign_z = -1; else sign_z = 1;

                Rand.x = (1 - value_random) * sign_x;
                Rand.z = value_random * sign_z;
                transform.parent.position += (Rand * speed * Time.deltaTime);
                Vector3 v;
                v = DirectionToRotation(Rand);
                quaternion = Quaternion.Euler(v.x, v.y, v.z);
                transform.parent.rotation = Quaternion.Slerp(transform.rotation, quaternion, Time.deltaTime*10f );
            }
        }

        //Moves towards target;
    else{
            transform.parent.position += (direction * speed * Time.deltaTime);
            Vector3 v;
            v= DirectionToRotation(direction);
            quaternion = Quaternion.Euler(v.x, v.y, v.z);
            transform.parent.rotation = Quaternion.Slerp(transform.rotation,quaternion, Time.deltaTime *10f);
        }
    }
    private void OnTriggerEnter(Collider Colider)
    {
        if (Colider.gameObject.name == "Plant_(Beta)(Clone)"&&Target==Vector3.zero)
        {
           
            Debug.Log("on vision");
            Target_name=Colider.gameObject.name;
            Target = Colider.gameObject.transform.position;
            Target.y = 0;
            Debug.Log(Target);
            //gets direction towars the target
            direction = GetDirection(transform.parent.position, Target);
            direction.y = 0;
            Debug.Log(direction);
           
        }
      
    }
   

    static Vector3 GetDirection(Vector3 from, Vector3 to)
    {
        // Calculate the direction vector
        Vector3 direction = to - from;

        // Normalize the direction vector to get a unit vector
        direction = Vector3.Normalize(direction);

        return direction;
    }
    public static Vector3 DirectionToRotation(Vector3 direction)
    {
        // Calculate yaw (rotation around the Y axis)
        float yaw = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // Calculate pitch (rotation around the X axis)
        float pitch = Mathf.Atan2(direction.y, Mathf.Sqrt(direction.x * direction.x + direction.z * direction.z)) * Mathf.Rad2Deg;

        // Roll is usually not required unless dealing with full 3D rotation
        float roll = 0f;

        return new Vector3(pitch, yaw, roll);
    }
    public void reset_vision()
    {
        Target = Vector3.zero;
        Curent_Colider.enabled = false;
        Curent_Colider.enabled = true;
    }
    public void pop_food()
    {
        Transfer.pop();
    }
  

}
