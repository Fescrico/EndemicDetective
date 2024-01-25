using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Behaviour : MonoBehaviour
{
    private float speed = 2.0f;
    public int[] schedule = new int[3];
    int counter = 0;
    private bool move = false;
    private Vector3 target;
    private Vector3 home;

    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
    }

    // Creates a schedule for each unit to follow
    void createSchedule()
    {
        for (int i = 0; i < 3; i++)
        {
            // Right now idea is each person can have up to 3 activities per day (with repeats allowed):
            // 1: Walk around, find the nearest point out of (Top, bot, left, right) and go there then circle the walking path
            // 2: Go to the central park (Green area in the middle) 
            // 3: Go to work (one house out of the many)
            // 4 (not generated only occurs at the end of day): Go home
            schedule[i] = Random.Range(1, 4);
        }
    }

    // Executes the action the schedule expects and shifts the counter by 1,  once all scheduled events are done reset counter and go back home.
    public void timeChange() 
    {
        
        if (counter != 3)
        {
            counter++;
        } 
        else
        {
            counter = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (Vector3.Distance(transform.position, target) < 0.001f)
            {
                // here should go the command change
                move = false;
            }
            // here should go bit to animate head bopping
        }
    }
}
