using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Animal_Spawner : MonoBehaviour
{
    public GameObject Animals;
    public Text Text_List;
    public GameObject UI_List_Text;
    public GameObject[] All_Animals = new GameObject[100];
    public GameObject Next_Button;
    public float SpawnInterval = 1;
    public float[,] Genomes = new float[100,5];
    public float[] Fitnes = new float[100];
    public float Animals_Timer;
    public float Time_Start;
    public float Next_Gen_Timer ;
    public float destroy_time=15;
    // Start is called before the first frame update
    void Start()
    {
        Time_Start=Time.time;
        for (int i = 0; i < 5; i++)

            for (int index = 0; index < 5; index++)

            
               Genomes[i, index] = 5 * Random.value;
                
            

        //genome setup
        
        for (int i=0;i<5;i++)
       
        {
            Animals.GetComponent<test_transfer>().set_genome(Genomes[i,0], Genomes[i, 1], Genomes[i, 2], Genomes[i, 3], Genomes[i, 4],i);
          
            Vector3 location_rand = Vector3.one * 100;

  
            

            location_rand.y = 0;
            location_rand.z *= Random.value;
            location_rand.x *= Random.value;

            GameObject newObject= Instantiate(Animals, location_rand, Quaternion.identity);
            All_Animals[i] = newObject;
          
        }
    }
    void Update()
    {

        if (Time.time > destroy_time + Time_Start) 
        { Next_Button.SetActive(true); }
        {
            Text_List.text = "";

            for (int i = 0; i < 5; i++)
                Text_List.text += "ID=" + i.ToString() + " score:" + All_Animals[i].GetComponent<test_transfer>().get_food().ToString() + System.Environment.NewLine;
        }
    }
    public void enable()
    {
        this.enabled=true;
    }


   

   
}
