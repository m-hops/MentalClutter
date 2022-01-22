using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFall : MonoBehaviour
{
    public int ySpawn = 353;
    public int yEnd = -353;
    public int targetCenter = -280;
    public int targetHeight = 100;
    public float secondsToFall;
    public KeyCode keyCode;

    private float timer = 0f;
    private float percent;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 difference;

    void Start()
    {
        startPoint = new Vector2(0, ySpawn);
        endPoint = new Vector2(0, yEnd);
        difference = endPoint - startPoint;
        transform.localPosition = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= secondsToFall)
        {
            timer += Time.deltaTime;
            percent = timer / secondsToFall;
            transform.localPosition = startPoint + difference * percent;

            if (Input.GetKeyDown(keyCode) && isInTargetZone())
            {
                ScoreManager.instance.IncrementSuccesses();
                Destroy(gameObject);
            }
        }
        else
        {
            ScoreManager.instance.IncrementFailures();
            Destroy(gameObject);
        }
    }

    private bool isInTargetZone()
    {
        return (Mathf.Abs(transform.localPosition.y - targetCenter) < targetHeight);
    }
}