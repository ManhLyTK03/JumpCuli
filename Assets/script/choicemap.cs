using UnityEngine;
using UnityEngine.SceneManagement;

public class choiceMap : MonoBehaviour
{
    public static bool checkMap = true;
    public void clickPlay(int lever)
    {
        if(GameManager.instance.GetHighScore()/10 >= lever){
            SceneManager.LoadScene(lever);
            checkMap = false;
        }
    }
}
