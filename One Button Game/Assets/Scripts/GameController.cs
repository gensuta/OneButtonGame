using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float matchTimer; // checking how long the match is going. might not need anymore
   

    public int score; // amt of homies kissed

    public bool gameEnd;

    // Start is called before the first frame update
    void Start()
    {
       
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!gameEnd)
        {
            matchTimer += Time.deltaTime;
        }

    }

 
}
