using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    float turningSpeed = 20f;
    Animator myAnimator;
    Rigidbody myRigidBody;
  
    Vector3 playerMovement;
    Quaternion playerRotation = Quaternion.identity;

    //### *** Task 1 - a *** ###
    //### *** Add a type of component that allow us to play SFX  ***###

    AudioSource walkingSound;

    bool isPlaying; 

    void Start ()
    {
        myAnimator = GetComponent<Animator> ();
        myRigidBody = GetComponent<Rigidbody> ();

        //### *** Task 1 - a *** ###
        //### *** grab the component needed  ***###  
        
       walkingSound = gameObject.GetComponent<AudioSource>();

    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");        
        playerMovement.Set(horizontal, 0f, vertical);
        playerMovement.Normalize ();
        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        myAnimator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            //### *** Task 1 - a *** ###
            //write code that says: if it is not playing the SFX, play it
            
            if(isPlaying == false){
                walkingSound.Play();
                isPlaying = true;
            }
           
        }
        else
        {
            //### *** Task 1 - a *** ###
            //Write code to stop playing audio
            if(isPlaying == true){    
                walkingSound.Stop();
                isPlaying = false;
            }
          
        }

        Vector3 desiredForwardDirection = Vector3.RotateTowards (transform.forward, playerMovement, turningSpeed * Time.deltaTime, 0f);
        playerRotation = Quaternion.LookRotation (desiredForwardDirection);
    }

    void OnAnimatorMove ()
    {
        myRigidBody.MovePosition (myRigidBody.position + playerMovement * myAnimator.deltaPosition.magnitude);
        myRigidBody.MoveRotation (playerRotation);
    }
}