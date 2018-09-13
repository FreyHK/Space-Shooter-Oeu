using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    public AnimationCurve SpeedOverTime;
	
	void Update () {
        float t = Mathf.Clamp01(Time.unscaledTime / 180f);
        Time.timeScale = 1f + SpeedOverTime.Evaluate(t);
	}
}
