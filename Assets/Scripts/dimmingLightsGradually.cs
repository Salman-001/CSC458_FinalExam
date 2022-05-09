using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dimmingLightsGradually : MonoBehaviour
{
    Light pointLight;

    // Start is called before the first frame update
    void Start()
    {
        pointLight = gameObject.GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(waitAndDecrease());
        
    }

    public IEnumerator waitAndDecrease(){
        pointLight.intensity -= 0.005f;
        yield return new WaitForSeconds(1f);
    }
}
