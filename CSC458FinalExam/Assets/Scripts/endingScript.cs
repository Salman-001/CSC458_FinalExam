using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;


public class endingScript : MonoBehaviour
{
    GameObject gui3;
    TextMeshProUGUI msg3;
    [Tooltip("Scriptable Object that contains the busted times")]
    [SerializeField] scoreTypeSO score;

    private void Start() {
        gui3 = GameObject.FindWithTag("alert3");
        msg3 = gui3.GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other) {

        //
        if (other.gameObject.tag == "Player") {

            msg3.text = "You Won!";

            //saves the number of times busted
            PlayerPrefs.SetInt("busted_score", score.bustedTimes);
            PlayerPrefs.Save();
            
            //resetting the busted times for the next time played
            score.bustedTimes = 0;

            //ending the game
            stopGame.stopPlaying();
        }

    }

    public class stopGame : Editor {

        public static void stopPlaying () {
            EditorApplication.isPlaying = false;
        }
    }

}