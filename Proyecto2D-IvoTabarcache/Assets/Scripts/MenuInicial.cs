using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Gestiona las acciones del Menú Principal.
public class MenuInicial : MonoBehaviour
{
    //Permite pasar al nivel 1 luego de presionar el boton "Play" en el Menú Inicial.
    public void Jugar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Permite salir del juego en caso de exportarlo como programa.
    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }
}
