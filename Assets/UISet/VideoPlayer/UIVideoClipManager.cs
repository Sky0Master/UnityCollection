using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIVideoClipManager : MonoBehaviour
{
    public GameObject curClipGo;
    public UIMutiVideoPlayer mutivideoPlayer;
    public void Delete()
    {
        curClipGo.SetActive(false);
        mutivideoPlayer.Reset();
    }
    
    
}
