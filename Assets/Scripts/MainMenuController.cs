using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MainMenuController : MonoBehaviour
{

    public void PlayGame()
    {
        int selectedChar = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        GameManager.ins.SelectedCharIndex = selectedChar;
        SceneManager.LoadScene("Gameplay");
    }
} //class 
