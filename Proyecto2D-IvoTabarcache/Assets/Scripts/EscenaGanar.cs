using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Gestiona la escena de victoria.
public class EscenaGanar : MonoBehaviour
{
    //Permite volver al Menú Principal.
    public void Volver(){
        SceneManager.LoadScene(0);
    }
}
