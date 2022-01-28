using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour
{
    public Slider slider;
    public static GameProgress instance;

    void Awake()
    {
      slider = GetComponent<Slider>();
    }   
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementProgress(int progress)
    {
        slider.value += progress;
        Debug.Log("Slide value: " + slider.value);
    }
}
