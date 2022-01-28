using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjController : MonoBehaviour
{
     [SerializeField]PlayerManager playerManager;
    [SerializeField] FriendController friend;   
    [SerializeField] List<FriendController> friendController;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            
            rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
            GetComponentInChildren<SkinnedMeshRenderer>().material = playerManager.collectedCharacterMaterial;
        }
  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CollectableObj")
        {
            collision.gameObject.GetComponent<FriendController>().isfriend = true;
            // friend.isfriend = true;
            if (!playerManager.collidedList.Contains(collision.gameObject))
            {
                collision.gameObject.tag = "CollectedObj";
                collision.transform.parent = playerManager.collectedPoolTransform;
                playerManager.collidedList.Add(collision.gameObject);
                collision.gameObject.AddComponent<CollectableObjController>();
            }
        }
        if(collision.gameObject.tag == "Obstacle")
        {
            Dead();
            GameObject particle = Instantiate(playerManager.particlePrefab,transform.position,Quaternion.identity);
            Destroy(particle, 1);
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }



    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectableList")
        {
            other.transform.GetComponent<BoxCollider>().enabled = false;
            other.transform.parent = playerManager.collectedPoolTransform;

            foreach (Transform child in other.transform)
            {
                if (playerManager.collidedList.Contains(child.gameObject))
                {
                    playerManager.collidedList.Add(child.gameObject);
                    child.gameObject.tag = "CollectedObj";
                    child.gameObject.AddComponent<CollectableObjController>();
                }
            }
        }
    }*/
}
