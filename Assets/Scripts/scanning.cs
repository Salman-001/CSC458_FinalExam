using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class scanning : MonoBehaviour
{
    GameObject gui;
    TextMeshProUGUI msg;

    GameObject gui2;
    TextMeshProUGUI msg2;

    [SerializeField] scoreTypeSO score;

    private void Awake() {
        
        //find the game object using the tag
        //get the text from UI
        gui = GameObject.FindWithTag("alert");
        msg = gui.GetComponent<TextMeshProUGUI>();

        gui2 = GameObject.FindWithTag("alert2");
        msg2 = gui2.GetComponent<TextMeshProUGUI>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //setting the initial text when the game starts
        msg.text = "";
        msg2.text = $"Busted: {score.bustedTimes}";
        
    }

    private void OnTriggerEnter(Collider other) {
        
        StartCoroutine(waitAndUpdate());

    }

    public IEnumerator waitAndUpdate(){

        msg.text = "Busted!";

        msg2.text = $"Busted: {score.bustedTimes}";

        yield return new WaitForSeconds(1f);

        msg.text = "";

        //increment score
        score.bustedTimes++;

        //reload the scene
        SceneManager.LoadScene("FinalExam");

    }

}
