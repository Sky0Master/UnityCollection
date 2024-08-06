using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFade : MonoBehaviour
{

    [SerializeField]
    float _duration = 0.5f;
    [SerializeField]
    ParticleSystem _particle;
    Material _material;
    private void Awake()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }
    private void Update()
    {
        //TEST
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartEffect();
        }
    }

    public void StartEffect()
    {
        _particle.Play();
        _material.DOFloat(-1, "_Strength", _duration);
    }
    
}
