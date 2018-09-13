using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameHealth : MonoBehaviour {

	public Health objectHealth;
	public Text healthText;
	public Image healthBarFill;

	private int startHealth = 0;

	void Start () {
		startHealth = objectHealth.healthValue;
		if(healthText != null) {
			healthText.text = objectHealth.healthValue.ToString ();
		}
		if(healthBarFill != null) {
			healthBarFill.fillAmount = (float)objectHealth.healthValue / (float)startHealth;
		}
	}
	
	void Update () {
		if(healthText != null) {
			healthText.text = objectHealth.healthValue.ToString ();
		}
		if(healthBarFill != null) {
			healthBarFill.fillAmount = (float)objectHealth.healthValue / (float)startHealth;
		}
	}
}
