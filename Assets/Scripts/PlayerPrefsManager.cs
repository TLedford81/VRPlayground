using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{

    const string BB_HIGHSCORE_KEY = "bb_highscore";

    public static void SetBBHighScore(float score)
    {
        if (score >= 0f)
        {
            PlayerPrefs.SetFloat(BB_HIGHSCORE_KEY, score);
        }
        else
        {
            Debug.LogError("Score out of range");
        }
    }

    public static float GetBBHighsScore()
    {
        return PlayerPrefs.GetFloat(BB_HIGHSCORE_KEY);
    }
}