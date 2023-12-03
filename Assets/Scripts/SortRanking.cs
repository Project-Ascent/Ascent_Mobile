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
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetFloat("current", 100f);
        //PlayerPrefs.SetFloat("0BestScore", 202.122f);
        //PlayerPrefs.SetFloat("2BestScore", 180.554f);
        //PlayerPrefs.SetFloat("3BestScore", 120.1889f);
        //PlayerPrefs.SetFloat("1BestScore", 240.45f);*/
       
        current = PlayerPrefs.GetFloat("current");
        float tmpScore = 0f;
        int a = 0;
       
        for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            if (bestScore[i] == 0)
            {
                //print(i);
                bestScore[i] = int.MaxValue;
                a++;
            }
            
        }
        if (a > 4 && bestScore[0] == int.MaxValue)
        {
            print("dd");
            PlayerPrefs.SetFloat("0BestScore", current);
        }
        /*for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");
            
            if (bestScore[i] == int.MaxValue&&bestScore[0]!=0)
            {
                //print(i);
                bestScore[i] = current;
                
                break;
            }
            
        }*/
        
        for(int i = 0; i < 5; i++)
        {
            if (bestScore[i] > current)
            {
                print(bestScore[i]+" "+i);
                tmpScore = bestScore[i];
                bestScore[i] = current;

                current = tmpScore;
            }
        }
        System.Array.Sort(bestScore);
        //System.Array.Reverse(bestScore);
        /*for (int i = 0; i < 5; i++)
        {
            bestScore[i] = PlayerPrefs.GetFloat(i + "BestScore");

            while (bestScore[i] > current)
            {

                tmpScore = bestScore[i];
                bestScore[i] = current;
                PlayerPrefs.SetFloat(i + "BestScore", current);
                current = tmpScore;
                

                
            }

        }*/
        
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetFloat(i + "BestScore", bestScore[i]);
        }

        float c = PlayerPrefs.GetFloat("current");
        for (int i = 0; i < 5; i++)
        {
            rankScore[i] = PlayerPrefs.GetFloat(i + "BestScore");

        }
        string[] s = new string[5];
        for(int i = 0; i < 5; i++)
        {
            if (rankScore[i] == int.MaxValue)
            {
                rankScore[i] = 0;
            }
            rankScore[i] = Mathf.FloorToInt(rankScore[i]);
            s[i] = Mathf.FloorToInt(rankScore[i] / 60) + "m " + (rankScore[i] % 60) + "s";
        }
        Mathf.FloorToInt(rankScore[0]);
        text1.text = s[0];
        text2.text = s[1];
        text3.text = s[2];
        text4.text = s[3];
        text5.text = s[4];
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