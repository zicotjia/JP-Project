using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if  UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;
    
    private void Start() {
        ColorPicker.Init();
        ColorPicker.onColorChanged += NewColorSelected;
    }
    
    public void StartNew() {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void NewColorSelected(Color color) {
        MainManager.instance.teamColor = color;
    }
    
    public void Quit() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
    public void SaveColorClicked()
    {
        Debug.Log("Saved");
        MainManager.instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.instance.LoadColor();
        ColorPicker.SelectColor(MainManager.instance.teamColor);
    }
}
