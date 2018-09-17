using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Health PlayerHealth;

    public AnimationCurve SpeedOverTime;

    private void Start() {
        PlayerHealth.OnDeath += OnPlayerDeath;
        //Reset timer
        GameTime = 0f;
        IsGameOver = false;
    }

    bool IsGameOver = false;

    void Update () {
        if (!IsGameOver)
            UpdateGameTime();
    }

    public static float GameTime = 0f;

    void UpdateGameTime() {
        GameTime += Time.unscaledDeltaTime;
        //float t = Mathf.Clamp01(gameTime / 180f);
        //Time.timeScale = 1f + SpeedOverTime.Evaluate(t);
    }

    void OnPlayerDeath () {
        IsGameOver = true;
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame() {
        //Hide player
        PlayerHealth.gameObject.SetActive(false);
        
        yield return new WaitForSecondsRealtime(3f);
        
        SceneManager.LoadScene("Lose");
    }
}
