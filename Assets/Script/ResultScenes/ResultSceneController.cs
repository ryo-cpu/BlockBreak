using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResultSceneController : MonoBehaviour
{
    //各種オブジェクトの生成
    public GameObject scoreTextObject;      //スコア
    public GameObject gameResultObject;     //ゲームオーバーかゲームクリア

    // Start is called before the first frame update
    void Start()
    {
        //各種結果をオブジェクトに渡す

        this.scoreTextObject.GetComponent<TextMeshProUGUI>().text = "SCORE : "+ SceneData.score;


        //GameOver
        if (SceneData.totalBlocks == 0 )
        {
            this.gameResultObject.GetComponent<TextMeshProUGUI>().text= "GAME CLEAR";
           
        }
        else
        {
            this.gameResultObject.GetComponent<TextMeshProUGUI>().text = "GAME OVER";
           
        }
    }

    public void OnStartButtonPressed()
    {
        GameManager.instance.ReturnToStart();
    }
}
