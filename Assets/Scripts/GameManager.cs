using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UIを扱うために必要な名前空間

public class GameManager : MonoBehaviour
{
    public GameObject mainImage; //イラスト文字を持つGameObject
    public Sprite gameOverSpr; //GAMEOVER画像
    public Sprite gameClearSpr; //GAMECLEAR画像
    public GameObject panel; //パネル
    public GameObject restartButton; //RESTARTボタン
    public GameObject nextButton; //NEXTボタン

    Image titleImage; //イラスト文字を表示しているImageコンポーネント

    // Start is called before the first frame update
    void Start()
    {
        //画像を非表示にする
        Invoke("InactiveImage", 1.0f);
        //ボタン（パネル）を非表示にする
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.gameState == "gameclear")
        {
            //ゲームクリア
            mainImage.SetActive(true); //イラスト文字を表示
            panel.SetActive(true); //パネル（ボタン）を表示
            //RESTARTボタンの無効化
            Button bt = restartButton.GetComponent<Button>();
            bt.interactable = false; //Buttonコンポーネントのボタン有効化の変数をfalse
            mainImage.GetComponent<Image>().sprite = gameClearSpr; //GAMECLEARのイラスト文字に変更

            PlayerController.gameState = "gameend"; //何回もこの一連の処理を繰り返さないようにするため
        }
        else if(PlayerController.gameState == "gameover")
        {
            //ゲームオーバー
            mainImage.SetActive(true); //イラスト文字を表示する
            panel.SetActive(true); //パネル（ボタン）を表示する
            //NEXTボタンを無効化する
            Button bt = nextButton.GetComponent<Button>();
            bt.interactable = false;//Buttonコンポーネントのボタン有効化の変数をfalse
            mainImage.GetComponent<Image>().sprite = gameOverSpr; //GAMECLEARのイラスト文字に変更

            PlayerController.gameState = "gameend"; //何回もこの一連の処理を繰り返さないようにするため
        }
        else if(PlayerController.gameState == "playing")
        {
            //まだ何もしない
        }
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }
}
