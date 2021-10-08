using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public void ChangeScene(string MainMenu)
	{
		SceneManager.LoadScene(MainMenu);
	}
	public void Exit()
	{
		Application.Quit();
	}
}