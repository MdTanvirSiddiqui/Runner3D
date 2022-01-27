using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float movementSpeed;
    [SerializeField] float horizontalSpeed;
    public float posX;
    public bool startGame;
    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            GetInput();
        }
        
    }
 

    private void GetInput()
    {
        if (Input.GetButton("Horizontal"))
        {
            posX = Input.GetAxis("Horizontal");
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

            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            transform.position += transform.right * posX * horizontalSpeed * Time.deltaTime;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.5f, 6f), transform.position.y, transform.position.z);
        }
        else
        {
            playerAnim.SetBool("TurnLeft", false);
            playerAnim.SetBool("TurnRight", false);
        }
           
    }
}
