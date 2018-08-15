using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollPanel : MonoBehaviour {
    public Button[] allBtns;
    public RectTransform panel;
    public float[] pos;
    public Transform center;
    public int minButNum;
    public float butnDist;
    public bool isDragging;

    public float minDist;

	// Use this for initialization
	void Start () {
        pos = new float[allBtns.Length];
        butnDist = allBtns[1].transform.position.x - allBtns[0].transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < allBtns.Length; i++)
        {
            pos[i] = Mathf.Abs(center.position.x - allBtns[i].transform.position.x);
            float scaleFactor = 150f / pos[i];
            scaleFactor = Mathf.Clamp(scaleFactor, 0.5f, 1f);
            allBtns[i].GetComponent<RectTransform>().localScale = Vector3.one * scaleFactor;
        }

         minDist = Mathf.Min(pos);

        for (int i = 0; i < allBtns.Length; i++)
        {
            if (minDist == pos[i])
            {
                minButNum = i;
            }
        }

        if (!isDragging)
        {
            LerpToBttn(minButNum*-butnDist);
        }
	}

    void LerpToBttn(float pos)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, pos, Time.deltaTime * 10f);
        Vector2 newPos = new Vector2(newX, panel.anchoredPosition.y);
        panel.anchoredPosition = newPos;
    }
    public void StartDrag()
    {
        isDragging = true;
    }
    public void EndDrag()
    {
        isDragging = false;
    }
}
