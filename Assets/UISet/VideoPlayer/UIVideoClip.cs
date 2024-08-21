using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class UIVideoClip : MonoBehaviour,IPointerClickHandler
{

    public VideoClip video;
    public VideoPlayer videoPlayer;
    public float doubleClickInterval = 0.5f;
    float _clickTimer;
    int _clickTimes = 0;

    public UIVideoClipManager manager;
    private void Start() {
        _clickTimer = 0;
    }
    private void Update() {
        if(_clickTimes == 1)
            _clickTimer += Time.deltaTime;
        
        if(_clickTimer > doubleClickInterval)
        {
            _clickTimer = 0;
            _clickTimes = 0;
            return;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _clickTimes++;
        if(_clickTimer > 0 && _clickTimes == 2)
        {
            manager.curClipGo = gameObject;
            _clickTimer = 0;
            _clickTimes = 0;
            if(video != null && videoPlayer!= null)
            {    
                videoPlayer.clip = video;
                videoPlayer.Play();
            }
        }
    }

}
