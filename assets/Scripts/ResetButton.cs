using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ResetButton : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler{

    public Slider RestSlider;

    public bool isOver;

	private float heightButtons = 20f;
	private float widthButtons = 200f;

	private float actualWidthButton;
	private float cooldown;
	private float resetTime = 0.1f;

	private Chess chess;

	void Start () {
		//actualWidthButton = 0f;
		chess = GameObject.FindObjectOfType<Chess> ();
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(11);
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
    }

    public void OnPointerClick(PointerEventData eventdate)
    {
        if (RestSlider.value >= 1)
        {
            chess.Reset();
            Debug.Log("完成");
        }
            
    }
    /*
	void OnGUI () {
		if (GUI.Button (new Rect (0, Screen.height - heightButtons, widthButtons, heightButtons), new GUIContent("Nueva Partida", "Boton")) &&
		    actualWidthButton >= widthButtons){
			chess.Reset();
		}
		
		if(GUI.tooltip == "Boton"){
			actualWidthButton += 5f;
			if(actualWidthButton > widthButtons){
				actualWidthButton = widthButtons;
			}
			GUI.Button (new Rect (0, Screen.height - heightButtons, actualWidthButton, heightButtons), "");
			cooldown = Time.realtimeSinceStartup;
		}
	}
    */
	void Update () {

        if (isOver)
        {
            RestSlider.value += Time.deltaTime;
        }
        else
        {
            RestSlider.value = 0;
        }
        //if (Time.realtimeSinceStartup - cooldown > resetTime)
        //    actualWidthButton = 0;
	}
}
