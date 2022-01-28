using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public bool once = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            GameManager.instance.GameOver();
            Movement.instance.startGame = false;
        }
    }
}
