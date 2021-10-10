using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	public void StartGame(string NewLoadGameMenu)
	{
		SceneManager.LoadScene(NewLoadGameMenu);
	}
	public void Exit()
	{
		Application.Quit();
	}
	public void LoadAndNewGame(string CreateCharecter)
	{
		SceneManager.LoadScene(CreateCharecter);
	}
	public void Exit1()
	{
		Application.Quit();
	}
	public void CreateCharecter(string Game)
	{
		SceneManager.LoadScene(Game);
	}
	public void Exit2()
	{
		Application.Quit();
	}

}

















/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

	public void ChangeScene(string Game)
	{
		SceneManager.LoadScene(Game);
	}
	public void Exit()
	{
		Application.Quit();
	}
}*/