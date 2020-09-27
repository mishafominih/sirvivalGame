using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spread
{
    public float StartSpread;
    public float Diapazon;
    public float Intensity;
    public GameObject[] sprites;

    public Spread(float StartSpr, float Diap, float Intens, GameObject[] sprites, float normalise)
    {
        StartSpread = StartSpr;
        value = StartSpr;
        Diapazon = Diap;
        Intensity = Intens;
        this.sprites = sprites;
        timer = new Timer(normalise);
    }

    private float value;
    private Timer timer;
    public float GetDiapazon()
    {
        timer.Null();
        value *= Intensity;
        if (value > StartSpread + Diapazon)
        {
            value = StartSpread + Diapazon;
        }
        return UnityEngine.Random.Range(-value, value);
    }

    public void Update()
    {
        timer.Check();
        value -= (value - StartSpread) * timer.GetTime();
        setSprite();
    }

    private void setSprite()
    {
        sprites[0].gameObject.transform.localPosition = new Vector3(value, 0, 0);
        sprites[1].gameObject.transform.localPosition = new Vector3(-value, 0, 0);
        sprites[2].gameObject.transform.localPosition = new Vector3(0, value, 0);
        sprites[3].gameObject.transform.localPosition = new Vector3(0, -value, 0);
    }
}