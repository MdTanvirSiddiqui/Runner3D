using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player" || collision.gameObject.tag == "CollectedObj")
        {
            Debug.Log("Game Over");
            Movement.instance.startGame = false;
            GameManager.instance.Congratulation();
        }
    }
}
