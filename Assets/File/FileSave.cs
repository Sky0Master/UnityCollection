using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileSave : MonoBehaviour
{
    [SerializeField] string path;
    [SerializeField] Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        SaveImage();
    }

    private string GetDesktopPath()
    {
        // ��ƽ̨��ȡ����·��
        string basePath =
        #if UNITY_STANDALONE_WIN
                    Environment.GetEnvironmentVariable("USERPROFILE");
        #elif UNITY_STANDALONE_OSX
                    Environment.GetEnvironmentVariable("HOME");
        #elif UNITY_STANDALONE_LINUX
                    Environment.GetEnvironmentVariable("HOME");
        #else
                    ""; // ���ڷ�����ƽ̨�����ؿ��ַ���
        #endif
                return Path.Combine(basePath, "Desktop");
    }
    public void SaveImage()
    {
        //Debug.Log(GetDesktopPath());
        File.WriteAllBytes(GetDesktopPath()+"\\"+path ,texture.EncodeToPNG());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
