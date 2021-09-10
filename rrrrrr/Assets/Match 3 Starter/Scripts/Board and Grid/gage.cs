using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gage : MonoBehaviour
{
    Image gaaa;
    float maxHealth = 0;
    public static float health;

    // Start is called before the first frame update
    void Start()
    {
        gaaa = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        gaaa.fillAmount = health ;
    }
}
