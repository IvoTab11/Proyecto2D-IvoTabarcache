using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int lives;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    private void NewGame(){
        lives=3;
        score=0;

    }

    public void LevelComplete(){
        score+=1000;

    }

    public void LevelFailed(){
        lives--;

        if(lives<=0){
            NewGame();
        }

    }
}
