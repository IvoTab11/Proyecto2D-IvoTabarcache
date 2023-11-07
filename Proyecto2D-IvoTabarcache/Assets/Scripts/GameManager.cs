using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Gestiona algunos cambios de pantalla en el juego;
public class GameManager : MonoBehaviour
{
    //Se llama en PlayerMovements al colisionar con el objetivo. Permite cambiar de escena al completar el nivel.
    public void LevelComplete(){
        //Obtiene el indice de la escena que le sigue a la escena actual en la secuencia de escenas del proyecto.
       int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
       //Comprueba si la escena siguiente es menor a la cantidad total de escenas.
       if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
       {
        //Carga la escena siguiente si es que no es la ultima en el orden de escenas.
        SceneManager.LoadScene(nextSceneIndex);
       }
       else
       {
        //Carga la escena de Victoria.
        SceneManager.LoadScene(3); 
        }
    }
    
    //Se llama en PlayerMovements al colisionar con un obstaculo. Permite cambiar de escena al perder en un nivel.
    public void LevelFailed(){
        SceneManager.LoadScene(4);
    }
}
