﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public bool GameIsPaused = false;
    private GameObject PauseMenu;

    void Awake()
    {
        PauseMenu = GameObject.Find("PauseCanvas");
    }

    void Start()
    {
        // Resume at start of game
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (!DayNightCycle.onDayEndScreen && Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        // PauseMenu.transform.localScale = new Vector3(0, 0, 0);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("resuming");
        CoralPlacer.dragging = false;
    }
    public void Pause()
    {
        Pause(true);
    }
    public void Pause(bool showPauseMenu)
    {
        if (showPauseMenu)
            PauseMenu.SetActive(true);
        // PauseMenu.transform.localScale = new Vector3(1, 1, 1);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("pausing");
        CoralPlacer.dragging = false;
        Destroy(CoralPlacer.hologram);
    }
}
