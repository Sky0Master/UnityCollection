using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dialog : MonoBehaviour,IPointerClickHandler
{
    public string[] ChatText;
    public int StartIndex = 0;
    int _index;
    public TMP_Text tmp;
    public UnityEvent EndEvent;
    public Image CharacterImage;
    
    private void Start()
    {
        _index = StartIndex;
        tmp.text = ChatText[_index];
    }
    public void NextText()
    {
        if (_index + 1 < ChatText.Length)
        {
            _index++;
            tmp.text = ChatText[_index];
        }
        else
        {
            EndEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        NextText();
    }
}
