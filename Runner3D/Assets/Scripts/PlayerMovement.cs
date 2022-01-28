using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    public Movement movement;
    private Rigidbody rb;
    [SerializeField] bool isGrounded;
    public Animator playerAnim;
    public float walkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponentInChildren<SkinnedMeshRenderer>().material = playerManager.collectedCharacterMaterial;
        playerManager.collidedList.Add(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded();
        }
    }

    private void Grounded()
    {
        isGrounded = true;
        playerManager.playerState = PlayerManager.PlayerState.Move;
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        Destroy(this,1);
    }
}
