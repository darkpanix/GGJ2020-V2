﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    // How much blood to lose per second
    public float BloodLossRate = 5f;

    public GameEvent PatientDead;

    public GameObject MountingPoint;

    public bool IsDead=false;

    public SpriteRenderer BloodSprite;

    public Item Item;

    public float Blood = 100f;

    public float MaxBlood = 100f;

    private float _bloodHeight;

    void Awake() {
        _bloodHeight = BloodSprite.size.y;
    }

    void Update()
    {
        if (!IsDead)
        {
            Blood -= BloodLossRate * Time.deltaTime;

            if (Blood <= 0f)
            {
                PatientDead.Raise(this.gameObject);
                GetComponent<SpriteRenderer>().color = Color.black;
                IsDead = true;
            }

            BloodSprite.transform.localScale = Vector3.Lerp(new Vector3(1f, 0f, 1f), Vector3.one, Blood / MaxBlood);

            Item?.Effect(this);
        }

        
    }

    public void Heal(float healAmount)
    {
        Blood = Mathf.Min(Blood + healAmount, 100.0f);
    }
}
