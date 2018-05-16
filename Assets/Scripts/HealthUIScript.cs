using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIScript : MonoBehaviour {
    public Character player;
    private Slider _slider;
	// Use this for initialization
	void Start () {
        GameObject temp = GameObject.Find("HealthSlider");
        if(temp != null)
        {
            _slider = temp.GetComponent<Slider>();
            _slider.maxValue = player.HealthPoints;
            _slider.value = player.HealthPoints;
        }
	}
	
	// Update is called once per frame
	void Update () {
        _slider.value = player.HealthPoints;
	}
}
