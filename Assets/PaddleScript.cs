using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PaddleScript : MonoBehaviour
{
    public DotSpawnScript dotSpawnScript;
    public LogicScript gameLogic;
    public float moveSpeed;

    private int direction = 1;
    private bool canScore;
    private bool justScored;
    private bool gameOver;

    // Update is called once per frame
    void Update()
    {
        // rotate paddle as long as the game isn't over then check for a restart
        if (!gameOver) 
        { 
            Rotate();
        }
        else
        {
            gameLogic.endGame();
        }

        // check if target hit
        if (Input.GetMouseButtonDown(0))
        {
            // missed
            if (!canScore)
            {
                gameOver = true;
            }
            // scored
            else
            {
                justScored = true;

                // change direction of the paddle
                direction *= -1;

                // delete the target dot and spawn a new one
                dotSpawnScript.Delete();
                dotSpawnScript.Spawn(direction);

                // add to player score
                gameLogic.addScore(1);

                // increase speed
                moveSpeed += 2;
            }
        }

        // exit game
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }

    // rotate the paddle around the center
    private void Rotate()
    {
        transform.RotateAround(Vector3.zero, Vector3.back, moveSpeed * Time.deltaTime * direction);
    }

    // determine if the player can score or not
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canScore = true;
        justScored = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canScore = false;
        if (!justScored) { gameOver = true; }
    }
}
