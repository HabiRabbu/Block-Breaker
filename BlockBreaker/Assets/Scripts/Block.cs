using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject blockVFX;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus gameStatus;

    [SerializeField] int timesHit;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        BreakableBlockCount();
    }

    private void BreakableBlockCount()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.countBreakableBlocks();
        }
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit == maxHits || timesHit > maxHits)
        {
            triggerVFX();
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int index = timesHit - 1;
        if (hitSprites[index] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[index];
        }

    }

    private void DestroyBlock()
    {
        level.countDestroyed();
        gameStatus.addScore();
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 0.3f);
        Destroy(gameObject);
    }

    private void triggerVFX()
    {
        GameObject VFX = Instantiate(blockVFX, transform.position, transform.rotation);
        Destroy(VFX, 2f);
    }
}
