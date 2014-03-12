using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
    private GUIStyle centeredStyle;
    public Font font;
    public string gameTitle;
    public int height;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) Application.LoadLevel("game");
	}

    void OnGUI() {
        centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;
        centeredStyle.font = font;
        //camera.backgroundColor = new Color32(0, 0, 0, 0);

        GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 - height, 400, 800), "<color=white><size=50> " + gameTitle + "</size></color>", centeredStyle);

        GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 + 250, 400, 800), "<color=white><size=15>Press any key to start</size></color>", centeredStyle);

        GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 + 90, 400, 800), "<color=white><size=10>a game made for #cyberpunkjam by</size></color>", centeredStyle);
        GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 + 110, 400, 800), "<color=white><size=10>Team 2UP</size></color>", centeredStyle);

        GUI.Label(new Rect((Screen.width / 2) - 200, Screen.height / 2 + 160, 400, 800), "<color=white><size=10>Music by: DST</size></color>", centeredStyle);
    }

}
