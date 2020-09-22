using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorMovement : MonoBehaviour // should be on the object moving on the meter
{

    public float startX, endX; // it will keep moving back and forth between these two objects
    public float middleX; // you can do actions if the indicator stops on or is close to middleX
    Vector3 myPos;
    public bool didStop; // did the player press/let go of space?
    bool isMovingLeft;

    public float stunTimer = 0f;

    GameController gc;
    public float speed;

    public bool wasStunned;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        speed = Random.Range(0.01f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 0) speed = 0.01f;
        if (!didStop && !gc.gameEnd)
        {
            if (isMovingLeft) transform.position += (Vector3.left * speed);
            else transform.position += (Vector3.right * speed);

            if (transform.position.x >= endX) isMovingLeft = true;
            if (transform.position.x <= startX) isMovingLeft = false;

        }


        if (stunTimer > 0f) stunTimer -= Time.deltaTime;
        else if (wasStunned)
        {
            didStop = false; // when stun wears off, bar moves again
            wasStunned = false;
        }

    }

    public bool canDoAction() // if this is called and the x pos is close to middle x it returns true!
    {
        // should have a timer go off so that there's a lil delay before you can try again

        if (Mathf.Abs(transform.position.x - middleX) < 0.2f)
        {
            didStop = true;
            return true;
        }

        return false;
    }
}
