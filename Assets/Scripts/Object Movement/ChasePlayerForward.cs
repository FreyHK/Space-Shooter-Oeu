using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerForward : MonoBehaviour {

    // Objektet, som vi skal følge efter.
    private PlayerControlForward Player;

    // Hastigheden, som vi skal bevæge os med.
    public TimedVariable MoveSpeed = new TimedVariable();

    //Higher value = faster reaction time
    public TimedVariable ReactionSpeed = new TimedVariable();

    float randomWeight = 1f;

    Rigidbody2D body;

    public enum AI_Type
    {
        Follow,
        CopyDirection,
        PredictPlayer,
        Wander
    }

    public AI_Type AI = AI_Type.PredictPlayer;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Player = FindObjectOfType<PlayerControlForward>();

        randomWeight = Random.Range(2.5f, 10f);

        //Set starting AI
        SelectAI();
        InvokeRepeating("SelectAI", Random.Range(2f, 10f), 5f);
    }

    void SelectAI () {
        AI = (AI_Type)Random.Range(0, 4);
    }

    Vector2 HeadingDir = Vector2.right;

    void Update() {

        if (Player != null)
            UpdateHeadingDirection();

        float moveSpeed = MoveSpeed.GetValue(GameController.GameTime);
        // Bevæger objektet i den beregnede retning, med den indstillede hastighed.
        body.MovePosition(body.position + HeadingDir * moveSpeed * Time.deltaTime);
    }

    void UpdateHeadingDirection () {
        Vector2 dir = Vector2.zero;

        switch (AI) {
            case AI_Type.Follow:
                dir = Follow();
                break;
            case AI_Type.CopyDirection:
                dir = CopyDirection();
                break;
            case AI_Type.PredictPlayer:
                dir = PredictPlayer();
                break;
            case AI_Type.Wander:
                dir = Wander();
                break;
        }
        //We want to lerp 'HeadingDir' towards this new value
        SetTargetDir(dir);
    }

    void SetTargetDir (Vector2 d) {
        // Normalize betyder at vektoren gives længden 1, men retning bibeholdes.
        d.Normalize();
        float speed = ReactionSpeed.GetValue(GameController.GameTime);
        HeadingDir = Vector2.Lerp(HeadingDir, d, Time.deltaTime * speed);
        HeadingDir.Normalize();
    }

    Vector2 preferredDir = Vector2.zero;

    Vector2 Follow()
    {
        if (preferredDir == Vector2.zero)
            preferredDir = (Vector2)Random.onUnitSphere;
        
        Vector2 retning = Player.transform.position - transform.position;

        retning += preferredDir * randomWeight;

        return retning;
    }

    Vector2 CopyDirection()
    {
        Vector2 retning = (Vector2)Player.transform.up; //Player.transform.position - transform.position;
        //retning += (Vector2)Player.transform.up * randomWeight;

        return retning;
    }

    //How many units in front of the player do we want to follow?
    float predictRange = 7f;

    Vector2 PredictPlayer()
    {
        Vector2 prediction = Player.transform.position + Player.transform.up * predictRange;

        //Follow prediction
        Vector2 retning = prediction - (Vector2)transform.position;

        return retning;
    }

    Vector2 Wander() {
        return (Vector2)Random.onUnitSphere;
    }
}
