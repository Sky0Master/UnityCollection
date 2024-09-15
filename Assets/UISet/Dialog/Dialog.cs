using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public struct ChatSentence
{
    public string text;
    public Sprite characterSpr;
}

public class Dialog : MonoBehaviour,IPointerClickHandler
{
    public ChatSentence[] ChatText;
    public int StartIndex = 0;
    int _index;
    public TMP_Text tmp;
    public UnityEvent EndEvent;
    public Image CharacterImage;

    public void SetSentence(int index)
    {
        tmp.text = ChatText[index].text;
        CharacterImage.sprite = ChatText[index].characterSpr;
    }

    private void Start()
    {
        _index = StartIndex;
        if(CharacterImage==null)
            CharacterImage = transform.Find("Character").GetComponent<Image>();
        SetSentence(_index);
    }
    public void NextText()
    {
        if (_index + 1 < ChatText.Length)
        {
            _index++;
           SetSentence(_index);
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
