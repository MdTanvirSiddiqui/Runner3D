using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Material collectedCharacterMaterial;
    public PlayerState playerState;
    public List<GameObject> collidedList;

    public Transform collectedPoolTransform;
    public enum PlayerState
    {
        Stop,
        Move
    }
}
