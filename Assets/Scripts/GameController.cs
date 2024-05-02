using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public int time = 0;
    public bool pause = false;
    public static Action OnWin;
    public static Action OnLose;
    public  GameObject PanelWin;
    public GameObject PanelLose;

    [Header("SceneController")]

    [SerializeField] private SceneController scenes;
    [Header("Handlers")]
    [SerializeField] private HandleMessage lose;
    [SerializeField] private HandleMessage win;
    [SerializeField] private GlobalValues score;
    [SerializeField] private GlobalValues TimeR;
    private void Awake()
    {
        Time.timeScale = 1;
        score.ValueInt = 0;
        TimeR.ValueFloat = 0;
    }
    private void OnEnable()
    {
        pause = true;
        time = 1;
    }
    void Start()
    {
        //OnWin = GoWin;
        //OnLose = GoEnd;
        lose.ActionGeneral += GoEnd;
        win.ActionGeneral += GoWin;
    }

    private void GoWin()
    {
        //PanelWin.SetActive(true);
        Time.timeScale = 0;
        scenes.IrScene(2);
    }
    private void GoEnd()
    {
        //PanelLose.SetActive(true);
        Time.timeScale = 0;
        scenes.IrScene(2);
    }
    public void PauseBtn()
    {
        if (pause) {

            Time.timeScale = 1;
            pause = false;
        }
        else
        {
            Time.timeScale = 0;
            pause = true;
        }
    }
}
