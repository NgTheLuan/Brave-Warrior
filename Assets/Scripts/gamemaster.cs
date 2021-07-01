using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemaster : MonoBehaviour
{

    public int points = 0;
    public int highscore = 0;

    public Text pointtext;
    public Text Hightext;
    public Text Inputtext;

    // Use this for initialization
    void Start()
    {
        Hightext.text = ("HighScore: " + PlayerPrefs.GetInt("highscore")); //PlayerPrefs dùng để lưu điểm
        highscore = PlayerPrefs.GetInt("highscore", 0);

        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene(); //lấy giá trị scence đang chơi
            if (ActiveScreen.buildIndex == 0) //buildIndex là giá trị đầu tiên
            {
                PlayerPrefs.DeleteKey("points"); //Points sẽ không điều chỉnh
                points = 0;
            }
            else
                points = PlayerPrefs.GetInt("points"); //lưu điểm qua các màng tiếp theo
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Scores: " + points);
    }
}