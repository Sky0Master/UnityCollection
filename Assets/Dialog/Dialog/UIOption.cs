using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIOption : MonoBehaviour,IPointerClickHandler
{
    public UnityEvent ChooseEvent;
    public string OptionText;
    public TMP_Text optionTMP;
    public GameObject root;
    
    private void OnValidate()
    {
        if(optionTMP != null)
        {
            optionTMP.text = OptionText;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ChooseEvent?.Invoke();
        root.SetActive(false);
    }
    // Start is called before the first frame update

}
