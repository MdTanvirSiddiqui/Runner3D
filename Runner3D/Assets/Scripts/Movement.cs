using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float movementSpeed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] bool inArea;
    public float posX;

    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
 

    private void GetInput()
    {
        if (Input.anyKey)
        {
            posX = Mathf.Clamp( Input.GetAxis("Horizontal"),-8f,8f);
            if (posX > 0)
            {
                playerAnim.SetBool("TurnLeft", false);
                playerAnim.SetBool("TurnRight", true);
            }
            else if (posX < 0)
            {
                playerAnim.SetBool("TurnRight", false);
                playerAnim.SetBool("TurnLeft", true);
            }

            Debug.Log("Player position: " + transform.position.x);
            Debug.Log("Is Player in area: " + inArea);
           
               // transform.position += transform.forward * movementSpeed * Time.deltaTime;
                transform.position += transform.right * posX * horizontalSpeed * Time.deltaTime;
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f),movementSpeed*Time.deltaTime,0);
        }
        else
        {
            playerAnim.SetBool("TurnLeft", false);
            playerAnim.SetBool("TurnRight", false);
        }
           
    }
}
