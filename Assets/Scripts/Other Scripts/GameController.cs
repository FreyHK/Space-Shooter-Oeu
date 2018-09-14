using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Health PlayerHealth;


    public AnimationCurve SpeedOverTime;

    private void Start() {
        PlayerHealth.OnDeath += OnPlayerDeath;
    }

    void Update () {
        UpdateGameSpeed();
    }

    float gameTime = 0f;

    void UpdateGameSpeed() {
        gameTime += Time.unscaledDeltaTime;
        float t = Mathf.Clamp01(gameTime / 180f);
        Time.timeScale = 1f + SpeedOverTime.Evaluate(t);
    }

    void OnPlayerDeath () {
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame() {
        //Hide player
        PlayerHealth.gameObject.SetActive(false);
        
        yield return new WaitForSecondsRealtime(3f);
        print("Load");
        
        SceneManager.LoadScene("Lose");
    }
}
