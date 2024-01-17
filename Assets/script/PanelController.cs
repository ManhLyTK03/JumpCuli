using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    private bool isPanelVisible = false;
    public GameObject panelObject;
    public float timedelay;
    public void SetPanelVisibility(bool isVisible)
    {
        float delay = 0.0f;
        checkJump.landed = !isPanelVisible;
        if (isVisible != isPanelVisible)
        {
            isPanelVisible = isVisible;
        }
        if(isVisible){
            delay = timedelay;
        }
        else{
            Time.timeScale = 1.0f;
        }
        Invoke("panelMap", delay);
    }
    void panelMap(){
        panelObject.SetActive(isPanelVisible);
        if(isPanelVisible && timedelay == 0.0f){
            Time.timeScale = 0f;
        }
    }
}
