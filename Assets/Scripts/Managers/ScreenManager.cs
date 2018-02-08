using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
	public Texture2D cursorTexture;
	public GameObject inGameMenu;
    public Transform Player;
	public enum GameScreen
	{
		InGameMenu
	}

	private void Start()
	{
		Cursor.SetCursor(cursorTexture, new Vector2(6, 0), CursorMode.ForceSoftware);

		inGameMenu.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			bool openMenu = !inGameMenu.activeInHierarchy;
			GameManager.SetGameState(openMenu ? GamePlayState.GameMenu : GamePlayState.Gameplay);
			Debug.Log("Cursor.visible: " + Cursor.visible);
			inGameMenu.SetActive(openMenu);

            int timeScale = openMenu ? 0 : 1;

            Time.timeScale = timeScale;

            Player.GetComponent<FirstPersonController>().enabled = !openMenu;
		}
	}
}