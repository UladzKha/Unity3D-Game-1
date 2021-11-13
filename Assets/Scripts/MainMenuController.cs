using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
       var selectedCharacter = int.Parse(EventSystem.current.currentSelectedGameObject.name);

       Debug.Log("Index: " + selectedCharacter);
       // SceneManager.LoadScene("Gameplay");
    }
}
