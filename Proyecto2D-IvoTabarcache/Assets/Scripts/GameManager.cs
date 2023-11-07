using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int lives;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        //NewGame();
    }

    // Update is called once per frame
    // private void NewGame(){
    //     // lives=3;
    //     // score=0;

    // }

    public void LevelComplete(){
        //score+=1000;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
    
       if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
       {
        SceneManager.LoadScene(nextSceneIndex);
       }
       else
       {
        SceneManager.LoadScene(3); 
        }
    }

    public void LevelFailed(){
        SceneManager.LoadScene(4);
        // lives-=1;
        // Debug.Log("Vidas: "+ lives);

        // if(lives<=0){
        //     NewGame();
        // }
        // else{
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // }
        

    }
}
