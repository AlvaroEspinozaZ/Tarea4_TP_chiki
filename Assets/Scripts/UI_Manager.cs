using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Manager : MonoBehaviour
{
    public Text Vidastxt;
    public Text[] Scoretxts;
    public Text[] Timetxt;
    public HealthSystem healthSystem;
    public PointSystem pointSystem;
    public GameObject pausePanel;
    public int ScenaToGo;
    float timer = 0;
    void Start()
    {
        
       
           
    }

    void Update()
    {
        timer += Time.deltaTime;
        
       
       
      
        if (Vidastxt != null)
        {
            Vidastxt.text = "Vidas: " + healthSystem.health;
        }
        if (Scoretxts != null)
        {
            for (int i = 0; i < Scoretxts.Length; i++)
            {
                Scoretxts[i].text = "Score: " + pointSystem.points;

            }
        }
        if (Timetxt != null)
        {
            for (int i = 0; i < Timetxt.Length; i++)
            {
                Timetxt[i].text = "Time: " + (int)timer;
            }
        }
    }
    public void ActivarPanel()
    {
        if(Time.timeScale == 1)
        {
            pausePanel.SetActive(false);
        }
        else if (Time.timeScale == 0)
        {
            pausePanel.SetActive(true);
        }
    }
    public void ReiniciarElJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void IrScene()
    {
        SceneManager.LoadScene(ScenaToGo);
    }

}
