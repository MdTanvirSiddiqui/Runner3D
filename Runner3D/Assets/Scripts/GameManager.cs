using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public Movement movement;
    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        movement.startGame = true;
    }
}
