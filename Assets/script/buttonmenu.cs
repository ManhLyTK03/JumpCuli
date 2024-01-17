using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class buttonmenu : MonoBehaviour, IPointerClickHandler
{
    public Transform playerMenu;
    public GameObject boomPrefab;
    public Sprite newImage;
    public Sprite setImage;
    public Rigidbody2D player;
    public Animator aniPlayer;
    public float speed;
    public static bool jump;
    void Start(){
        jump = false;
    }
    void Update(){
        if(!jump){
            aniPlayer.SetBool("jump", false);
            aniPlayer.SetBool("attack", false);
        }
    }
    public void OnPointerClick(PointerEventData eventData){
        if(!jump){
            player.velocity = new Vector2(player.velocity.x, speed);
            aniPlayer.SetBool("jump", true);
            jump = true;
        }
        Invoke("clickButton", 0.8f);
        Invoke("attack", 0.3f);
    }
    void clickButton(){
        Image buttonImage = GetComponent<Image>();
        buttonImage.sprite = newImage;
    }
    void attack(){
        aniPlayer.SetBool("attack", true);
    }
    public void clickPlay(){
        Invoke("nextScene", 2.0f);
        Invoke("aniBoom", 1.0f);
    }
    public void clickQuit(){
        Invoke("quitGame", 1f);
    }
    public void clickSet(){
        Invoke("setting", 1.5f);
    }
    void nextScene(){
        int lever = GameManager.instance.GetHighScore()/10;
        if(GameManager.instance.GetHighScore() == 0){
            lever = 1;
        }
        SceneManager.LoadScene(lever);
    }
    void quitGame(){
        Application.Quit();
    }
    
    private void aniBoom()
    {
        // Tạo một và đặt vị trí bắn ở vị trí của con boss
        GameObject boom = Instantiate(boomPrefab, transform.position, Quaternion.identity);
    }
    void setting(){
        Image buttonImage = GetComponent<Image>();
        buttonImage.sprite = setImage;
    }
}
