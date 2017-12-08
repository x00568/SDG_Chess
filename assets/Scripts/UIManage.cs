using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour
{

    private Chess chess;
    private ChessAI chessAI;

    private Text AIText;
    private Image AIBG;

    //UI
    public GameObject GameOverBG;
    public Text GameOverText;
    public GameObject Check;
    public Text CheckText;
    public Dropdown ModelList;

    public GameObject KingChecked;
    public Text KingCheckedText;

    private GameObject StartPanel;
    private Text TrunText;


    public Texture2D image;
    GUIStyle uistyle = new GUIStyle();
    void Awake()
    {
        AIText = GameObject.Find("Canvas/GamePanel/AIBG/AIText").GetComponent<Text>();
        AIBG = GameObject.Find("Canvas/GamePanel/AIBG").GetComponent<Image>();

        StartPanel = GameObject.Find("Canvas/StartPanel");
        TrunText = GameObject.Find("Canvas/GamePanel/TurnBG/TurnText").GetComponent<Text>();

        //事件监听
        ModelList.onValueChanged.AddListener(ModelChoose);

        //GUI皮肤设置
        uistyle.normal.background = image;
        uistyle.fontSize = 30;
        uistyle.alignment = TextAnchor.MiddleCenter;
    }

	// Use this for initialization
	void Start () {
        chess = GameObject.FindObjectOfType<Chess>();
        chessAI = GameObject.FindObjectOfType<ChessAI>();
	}
	
    void OnGUI()
    {
        if (chessAI.state == 1)
        {
            AIBG.gameObject.SetActive(true);
            AIText.text = "电脑选择棋子";
            return;
        }
        if (chessAI.state > 1)
        {
            AIBG.gameObject.SetActive(true);
            AIText.text = "电脑正在思考";
            return;
        }
        if (chessAI.state == 0 && Time.time - chessAI.cooldown < 1)
        {
            AIBG.gameObject.SetActive(true);
            AIText.text = "电脑完成操作";
            return;
        }

        AIBG.gameObject.SetActive(false);
        AIText.text = "";

        if (chess.white)
        {
            TrunText.text = "轮到白方了";
        }
        else
        {
            TrunText.text = "轮到黑方了";
        }

        if (chess. rightCastling)
            if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 32, 150, 22), "Enroque Derecho"))
               chess. rightCastle();
        if (chess. leftCastling)
            if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 52, 150, 22), "Enroque Izquierdo"))
               chess. leftCastle();

        if (chess.promotion)
        {
            if (!chess.playing)
            {
                
                GUI.Box(new Rect(Screen.width - 160, Screen.height - 32, 150, 22), "Promocionar a Reina");
                GUI.Box(new Rect(Screen.width - 160, Screen.height - 52, 150, 22), "Promocionar a Caballo");
            }
            else
            {
                if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 32, 150, 22), "Promocionar a Reina"))
                {
                   chess. promoteQueen();
                }
                if (GUI.Button(new Rect(Screen.width - 160, Screen.height - 52, 150, 22), "Promocionar a Caballo"))
                {
                    chess.promoteKnight();
                }
            }
        }
        if (chess.check)
        {
            Check.gameObject.SetActive(true);
            CheckText.text = "CHECK!";
        }
        else
            Check.gameObject.SetActive(false);

        if (Time.time - chess.checkedCooldown < 3)
        {
            KingChecked.SetActive(true);
            KingCheckedText.text = "Ilegal Move: King checked!";
        }
        else
        {
            KingChecked.SetActive(false);
        }

        if (chess.fin)
        {
            GameOverBG.SetActive(true);
            if (chess.white)
                GameOverText.text = "黑方胜";
            else
                GameOverText.text = "白方胜";
        }
        else
        {
            if (chess.starting == false)
            {
                if (!chess.playing)
                    GUI.Box(new Rect(Screen.width - 210, 20, 200, 80), "认输!", uistyle);
                else if (GUI.Button(new Rect(Screen.width - 210, 20, 200, 80), "认输!", uistyle))
                {
                    chess.theEnd();
                    chess.white = false;
                }
            }
        }
    }

    //对战模式选择
    public void ModelChoose(int index)
    {
        switch (index)
        {
            case 0:
               chess. whiteAI = false;
               chess.blackAI = true;
                break;
            case 1:
                chess.whiteAI = false;
                chess.blackAI = false;
                break;
            case 2:
                chess.whiteAI = true;
                chess.blackAI = true;
                break;
        }
    }

    //开始游戏
    public void StartGame()
    {
        chess.starting = false;
        StartPanel.SetActive(false);
    }

}
