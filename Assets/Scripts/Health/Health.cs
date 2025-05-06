using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {  get; private set; }

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    public static event Action OnPlayerDied;

    private void Awake()
    {
       currentHealth =  startingHealth;
       spriteRend = GetComponent<SpriteRenderer>();

    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // Player hurt logic (flashing, knockback, etc.) can go here
        }
        else
        {
            // Player dead
            GetComponent<PlayerMoviment>().enabled = false;

            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
                gm.GameOver();
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
