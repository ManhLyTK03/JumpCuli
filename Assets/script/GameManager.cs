using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string HIGH_SCORE = "HighScore";
    private const string SAVE_POINT_X = "SavePointx";
    private const string SAVE_POINT_Y = "SavePointy";

    public static GameManager instance;

    void Awake()
    {
        MakeSingleInstance();
        IsGameStartedForTheFirstTime();
    }

    void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }

    void MakeSingleInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

    public void SetSavePoint(Vector3 savePoint)
    {
        PlayerPrefs.SetFloat(SAVE_POINT_X, savePoint.x);
        PlayerPrefs.SetFloat(SAVE_POINT_Y, savePoint.y);
    }

    public Vector3 GetSavePoint()
    {
        float x = PlayerPrefs.GetFloat(SAVE_POINT_X);
        float y = PlayerPrefs.GetFloat(SAVE_POINT_Y);

        return new Vector3(x, y, 0f);
    }
}
