using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Animal : MonoBehaviour
{
    public Vision Vision;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider Colider)
    {
        if (Colider.gameObject.name != "Vision")
        {
            Debug.Log("Touched");
            Destroy(Colider.gameObject);
            Vision.reset_vision();
            Vision.pop_food();
        }
        Debug.Log("Touched");
    }

}
