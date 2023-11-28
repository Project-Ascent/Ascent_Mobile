using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SortRanking : MonoBehaviour
{
    private float[] bestScore = new float[5];
    private float[] rankScore = new float[5];
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text text4;
    public TMP_Text text5;
    private float current;
    // Start is called before the first frame update
    void Start()
    {
        current = PlayerPrefs.GetFloat("current");
        float tmpScore = 0f;
        for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");

            while (bestScore[i] < current)
            {
                tmpScore = bestScore[i];
                bestScore[i] = current;
                PlayerPrefs.SetFloat(i + "BestScore", current);
                current = tmpScore;

            }

        }
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestScore[i]);
        }

        float c = PlayerPrefs.GetFloat("current");
        for (int i = 0; i < 5; i++)
        {
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore");

        }

        text1.text = string.Format("{0:N3}", rankScore[0]);
        text2.text = string.Format("{0:N3}", rankScore[1]);
        text3.text = string.Format("{0:N3}", rankScore[2]);
        text4.text = string.Format("{0:N3}", rankScore[3]);
        text5.text = string.Format("{0:N3}", rankScore[4]);
        for (int i = 0; i < 5; i++)
        {
            if (c == rankScore[i])
            {
                Color Rank = new Color(255, 255, 0);
                switch (i)
                {
                    case 0:
                        text1.color = Rank;
                        break;
                    case 1:
                        text2.color = Rank;
                        break;
                    case 2:
                        text3.color = Rank;
                        break;
                    case 3:
                        text4.color = Rank;
                        break;
                    case 4:
                        text5.color = Rank;
                        break;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}