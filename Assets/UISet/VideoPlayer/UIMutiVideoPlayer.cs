using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIMutiVideoPlayer : MonoBehaviour
{
    public Transform videoClipParent;
    public VideoPlayer videoPlayer;
    List<float> _timerList;
    float _timer;

    bool _isPlaying = false;
    int _curClipIndex;

    public GameObject defaultImage;

    public void Reset()
    {
        _isPlaying = false;
        videoPlayer.Stop();
        _curClipIndex = 0;
        _timer = 0;
    }
    private void Update() {
        if(!videoPlayer.isPlaying)
            defaultImage.SetActive(true);
        else
            defaultImage.SetActive(false);

        if(!_isPlaying)
            return;
        _timer += Time.deltaTime;
        if(_timer > _timerList[_curClipIndex])
        {
            _curClipIndex++;
            if(_curClipIndex >= _timerList.Count)
            {
                _curClipIndex = 0;
                _isPlaying = false;
            }
            else{
                PlaySingle(_curClipIndex);
            }
        }
    }
    public void Play()
    {
        _timerList = new List<float>();
        for(int i = 0; i < videoClipParent.childCount;i++)
        {
            var uiClip = videoClipParent.GetChild(i).GetComponent<UIVideoClip>();
            if(uiClip.gameObject.activeSelf)
            {
                _timerList.Add((float)uiClip.video.length);
            }
        }
        if(_timerList.Count > 0)
        {
            _isPlaying = true;
            PlaySingle(0);
        }
    }
    void PlaySingle(int index)
    {
        var uiClip = videoClipParent.GetChild(index).GetComponent<UIVideoClip>();
        videoPlayer.clip = uiClip.video;
        videoPlayer.Play();
        _timer = 0;
    }

}
