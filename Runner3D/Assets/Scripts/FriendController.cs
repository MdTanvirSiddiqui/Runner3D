using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public Animator anim;
    public bool isfriend;
    public float posX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isfriend)
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
                anim.SetBool("TurnLeft", false);
                anim.SetBool("TurnRight", true);
            }
            else if (posX < 0)
            {
                anim.SetBool("TurnRight", false);
                anim.SetBool("TurnLeft", true);
            }
           // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else
        {
            anim.SetBool("TurnLeft", false);
            anim.SetBool("TurnRight", false);
        }

    }
}
