using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    private Rigidbody2D rigibody;
    public float jumpForce;
    private bool levelStart;
    public GameObject gameController;
    private int score;
    public Text scoreText;
    public GameObject message;
    public Button buttonExit;
    public Button playAgain;
    public GameObject gameOver;


    private void Awake() {
       rigibody = this.gameObject.GetComponent<Rigidbody2D>();
       levelStart = false;
       rigibody.gravityScale = 0;
       score = 0;
       scoreText.text = score.ToString();
       message.GetComponent<SpriteRenderer>().enabled = true;
       buttonExit.gameObject.SetActive(true);
       //bắt đầu chơi lại khi play again
       Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        // kiểm tra xem phím space có được bấm không
        if(Input.GetKeyDown(KeyCode.Space)){
            SoundController.instance.PlayThisSound("wing",1f);
            if(levelStart == false){
                levelStart = true;
                rigibody.gravityScale = 6;
                gameController.GetComponent<PipeGenerator>().enabledGeneratePipe = true;
                buttonExit.gameObject.SetActive(false);
                message.GetComponent<SpriteRenderer>().enabled = false;
            }
            BirdMoveUp();
        }
    }
    //Chim bay lên 1 khoảng
    private void BirdMoveUp(){
        rigibody.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Debug.Log("va chjam");
        SoundController.instance.PlayThisSound("hit",1f);
        // dừng lại
        Time.timeScale = 0;
        // hiện nút chơi lại
        playAgain.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        // cộng điển khi qua trigger
        score += 1;
        SoundController.instance.PlayThisSound("point",1f);
        scoreText.text = score.ToString();
    }
}
