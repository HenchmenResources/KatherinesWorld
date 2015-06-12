using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

    public string retryButton = "Retry";
    public Texture retryBtnText;
    public string worldMapButton = "World Map";
    public Texture worldMapBtnText;
    public string mainMenuButton = "Main Menu";
    public Texture mainMenuBtnText;
    private bool isWorldMap;


    // Use this for initialization
    void Start()
    {
        isWorldMap = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 90, 100, 30), retryBtnText))
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 120, 100, 30), worldMapBtnText))
        {
            isWorldMap = true;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 150, 100, 30), mainMenuBtnText))
        {
            Application.LoadLevel("menu");
        }
        if (isWorldMap)
        {
            GUI.Label(new Rect(Screen.width / 4, Screen.height / 5 * 4, Screen.width / 2, 20), "World Map Functionality coming soon.");
        }
    }
}
