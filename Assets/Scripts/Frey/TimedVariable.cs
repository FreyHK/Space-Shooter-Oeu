using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimedVariable {

    public float Min = 0f;
    public float Max = 10f;

    public AnimationCurve TimeChange;

    [Range(1f, 240f)]
    public float Duration = 180f;

    public float GetValue (float t) {
        float s = Mathf.Clamp01(t / Duration);
        float diff = Max - Min;

        //Caution: Very heavy on performance
        //Debug.Log("S: " + s + ", Diff: " + diff);

        return Min + TimeChange.Evaluate(s) * diff;
    }
}
