using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	GameObject[] pauseObjects;
	GameObject[] endObjects;
	public static int score;
	public static int highscore;

	public void StartGame()
    {
        SceneManager.LoadScene("SongSelection");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

	void Start()
	{
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
		endObjects = GameObject.FindGameObjectsWithTag("ShowOnEnd");
		hideEnd();
		score = 0;
	}

	void Update()
	{

		//Press ESC to pause and unpause
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hidePaused();
			}
		}

		/*
		 * if (game over)
		 * {
		 *		if (highscore > score) highscore = score;
		 * }
		 */
	}

	//Reloads the Level
	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	//controls the pausing of the scene
	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	//shows objects with ShowOnEnd tag
	public void showEnd()
	{
		foreach (GameObject g in endObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnEnd tag
	public void hideEnd()
	{
		foreach (GameObject g in endObjects)
		{
			g.SetActive(false);
		}
	}

	//loads inputted level
	public void LoadLevel(string level)
	{
		SceneManager.LoadScene(level);
	}
}
