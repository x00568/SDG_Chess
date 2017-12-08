using UnityEngine;
using System.Collections;

public class UndoButton : MonoBehaviour
{
    private Chess chess;
    private bool insideButton;
    private bool insideMenu;
    private float cooldown;

    public Texture2D image;
    GUIStyle uistyle = new GUIStyle();
    GUIStyle uistyle1 = new GUIStyle();
    void Start()
    {
        uistyle.normal.background = image;
        uistyle.fontSize = 30;
        uistyle.alignment = TextAnchor.MiddleCenter;

        uistyle1.normal.background = image;
        uistyle1.fontSize = 20;
        uistyle1.alignment = TextAnchor.MiddleLeft;

        chess = GameObject.FindObjectOfType<Chess>();
        insideMenu = false;
        insideButton = false;
    }

    void OnGUI()
    {
        if (chess.getStarting())
            return;

        if (chess.getEnemyPlaying() || chess.getHistory().Count == 0)
            GUI.Box(new Rect(Screen.width - 210, 120, 200, 80), "悔棋!", uistyle);
        else if (GUI.Button(new Rect(Screen.width - 210, 120, 200, 80), "悔棋!", uistyle))
            chess.undo();

        if (insideMenu || insideButton)
        {
            for (int i = 1; i <= chess.getHistory().Count; i++)
            {
                if (GUI.Button(new Rect(Screen.width - 170, 150 + 50 * i, 200, 50), (chess.getHistory().Count - i + 1) + ". " + ((ChessMove)chess.getHistory()[chess.getHistory().Count - i]).ToString(), uistyle1))
                    chess.undo(i);
            }
            for (int i = 1; i <= chess.getHistory().Count; i++)
            {
                if (chess.isWhiteTurn() && i % 2 == 1)
                    GUI.Box(new Rect(Screen.width - 210, 155 + 50 * i, 40, 40), chess.getBlackTex(), uistyle1);
                else if (!chess.isWhiteTurn() && i % 2 == 0)
                    GUI.Box(new Rect(Screen.width - 210, 155 + 50 * i, 40, 40), chess.getBlackTex(), uistyle1);
                else
                    GUI.Box(new Rect(Screen.width - 210, 155 + 50 * i, 40, 40), chess.getWhiteTex(), uistyle1);
            }
        }
    }

    void Update()
    {
        if (chess.getEnemyPlaying() || chess.getHistory().Count == 0)
        {
            insideButton = false;
            insideMenu = false;
            return;
        }

        if (Input.mousePosition.y < (Screen.height - 120) && Input.mousePosition.y > (Screen.height - 200) &&
            Input.mousePosition.x > Screen.width - 210 && Input.mousePosition.x < Screen.width - 100)
        {
            insideButton = true;
            cooldown = Time.realtimeSinceStartup;
        }

        if (insideButton && Input.mousePosition.y <= (Screen.height - 200) && Input.mousePosition.y >= (Screen.height - (200 + 50 * (chess.getHistory().Count + 1))) &&
            Input.mousePosition.x >= Screen.width -210 && Input.mousePosition.x <= Screen.width - 100)
        {
            insideMenu = true;
            cooldown = Time.realtimeSinceStartup;
        }

        if (Time.realtimeSinceStartup - cooldown > 0.1f)
        {
            insideButton = false;
            insideMenu = false;
        }
    }
}
