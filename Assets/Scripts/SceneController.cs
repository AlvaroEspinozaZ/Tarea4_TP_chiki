using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public int ScenaToGo;
    public void ReiniciarElJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void IrScene(int ScenaToGo)
    {
        SceneManager.LoadScene(ScenaToGo);
    }

}
