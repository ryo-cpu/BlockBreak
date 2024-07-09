using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // クラスの唯一のインスタンスを保持する静的変数
    public static ScoreScript instance;

    // スコアを表示するためのTextコンポーネント
    private TextMeshProUGUI scoreText;
    private int totalScore = 0;

    // Awakeメソッドでインスタンスの初期化を行う
    void Awake()
    {
        // インスタンスが存在しない場合はこのインスタンスを設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーンをまたいでもインスタンスを保持
        }
        else
        {
            Destroy(gameObject); // 既にインスタンスが存在する場合は新しいインスタンスを破棄
        }
    }
    void Start()
    {
        Initialize();
    }
    // スコアを更新し、Textコンポーネントに反映するメソッド
    public void ScoreManager(int score)
    {
        totalScore += score;
        UpdateScoreText();
    }

    // スコアをTextコンポーネントに表示するメソッド
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            this.scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + totalScore.ToString();
        }
        else
        {
            Debug.LogError("スコアテキストがnullです");
        }
    }

    //トータルのスコア
    public int GetCurrentScore()
    {
        return totalScore;
    }
    public void Initialize()
    {
        // タグでスコアテキストオブジェクトを検索して取得
        GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");
        if (scoreTextObject != null)
        {
            //scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
            UpdateScoreText();
        }
        else
        {
            Debug.LogError("スコアテキストオブジェクトが見つかりません");
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // シーンがロードされた後に再初期化
        StartCoroutine(InitializeAfterFrame());
    }

    private IEnumerator InitializeAfterFrame()
    {
        // フレームが終わるのを待つ
        yield return null;
        Initialize();
    }
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // イベント登録を解除
    }
}
