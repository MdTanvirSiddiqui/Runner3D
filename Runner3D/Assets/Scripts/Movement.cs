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
    public static Movement instance;

    private void Start()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (playerAnim ==null)
        {
            playerAnim = GameObject.FindGameObjectWithTag("CollectableObj").GetComponent<Animator>();
        }
        if (startGame)
        {
            GetInput();
        }
        else
        {
            playerAnim.SetBool("TurnLeft", false);
            playerAnim.SetBool("TurnRight", false);
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
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9f, 9.5f), transform.position.y, transform.position.z);
        }
        else
        {
            playerAnim.SetBool("TurnLeft", false);
            playerAnim.SetBool("TurnRight", false);
        }
           
    }
}
