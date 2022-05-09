using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingYouBuddy : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField] scanning scan;

    //range of the ray instantiated from the empty object
    public float range = 2f;

    // Update is called once per frame
    void Update()
    {

        if(Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, range)){
            // Debug.Log(hit.transform.name);
            //I mean the player but I am sure that unity is debugging and returning ghost instead of player
            if(hit.transform.name == "Ghost"){
                // Debug.Log("hello");

                //callet this function from scanning script
                StartCoroutine(scan.waitAndUpdate());
            }

        }
        
    }
}
