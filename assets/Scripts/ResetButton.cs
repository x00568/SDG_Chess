using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Slider RestSlider;
    public bool isOver;

    private Chess chess;

    void Start()
    {
        chess = GameObject.FindObjectOfType<Chess>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
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
            SceneManager.LoadScene(0);
        }
    }
    void Update()
    {
        if (isOver)
        {
            RestSlider.value += Time.deltaTime;
        }
        else
        {
            RestSlider.value = 0;
        }
    }
}
