using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSounds;
    [SerializeField] GameObject vfx;
   
    [SerializeField] Sprite[] damages;

    [SerializeField] int currentDamage;
    
    level levels;
    GameStatus gameStatus;

    private void Start()
    {
        countBreakableBlocks();

    }

    private void countBreakableBlocks()
    {
        levels = FindObjectOfType<level>();
        if (tag == "breakable")
            levels.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "breakable")
        {
            HandleDamage();
        }

    }

    private void HandleDamage()
    {
        currentDamage++;
        int maxDamage = damages.Length + 1;
        if (currentDamage >= maxDamage)
            DestroyBlock();
        else
            ShowNextSprite();
    }

    private void ShowNextSprite()
    {
        int spriteIndex = currentDamage - 1;
        GetComponent<SpriteRenderer>().sprite = damages[spriteIndex];
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSounds, Camera.main.transform.position);
        gameStatus = FindObjectOfType<GameStatus>();
        levels.blockDestroyed();
        gameStatus.addToScore();
        TriggerVFX();
        Destroy(gameObject);
    }

    private void TriggerVFX()
    {
        GameObject sparkle = Instantiate(vfx, transform.position, transform.rotation);
        Destroy(sparkle, 1f);
    }
}
