using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//기본 
using System.Linq;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    //시간 흐르게 할 것들
    public Text timeTxt;
    public GameObject endTxt;
    public GameObject card; 
    float time;
    public static gameManager I;
    public GameObject firstCard;
    public GameObject secondCard;

    public AudioClip match; //오디오클립과 
    public AudioSource audioSource; //오디오소스

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        int[] rtans = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        rtans = rtans.OrderBy(item => Random.Range(-1.0f, 1.0f)).ToArray();
        //ToArray=리스트 OrderBy=순서를정렬할게
        //Random.Range(-1.0f, 1.0f) 값을 랜덤으로 정렬할게 +4
        //2개씩 나오게 

        for (int i = 0; i < 16; i++)
        {
            GameObject newCard = Instantiate(card);
            //newCard를 cards로 옮겨줘! 
            newCard.transform.parent = GameObject.Find("cards").transform;

            //(0 + 4 / 1 + 4 / 2 + 4 / 3 + 4 / 3 + 4), (0 + 8 / 1 + 8 / 2 + ...), ()
            //그러려면 4를 나눈 나머지로 생각하기 
            float x = (i / 4) * 1.4f - 2.1f;
            float y = (i % 4) * 1.4f - 3.0f;
            newCard.transform.position = new Vector3(x, y, 0);

            //카드에 르탄그림 넣기 
            string rtanName = "rtan" + rtans[i].ToString();
            newCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(rtanName);
        }
        //i가 0, i가 10이하냐?, 조건만족x면 i++해라 / 조건만족하면끝! 
        Time.timeScale = 1.0f;//시간초기화? 
    }

    void Update()
    {
        //위에 것들로 써서 시간 흐르게 하기 
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");

        if (time > 30.0f)
        {
            endTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }

    public void isMatched()
    {
        //여기서 무엇인지 판단함 
        //FirstCard 와 secondCard 같은지 
        string firstCardImage = firstCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;
        string secondCardImage = secondCard.transform.Find("front").GetComponent<SpriteRenderer>().sprite.name;

        if (firstCardImage == secondCardImage)
        {
            audioSource.PlayOneShot(match);

            firstCard.GetComponent<card>().destroyCard();
            secondCard.GetComponent<card>().destroyCard();

            int cardsLeft = GameObject.Find("cards").transform.childCount;
            if (cardsLeft == 2)
            {
                endTxt.SetActive(true);
                Time.timeScale = 0.0f;
                //invoke("GameEnd", 1f);
            }
        }
        else
        {
            firstCard.GetComponent<card>().closeCard();
            secondCard.GetComponent<card>().closeCard();
        }

        firstCard = null;
        secondCard = null;
    }

    void GameEnd()
    {
        endTxt.SetActive(true);
        Time.timeScale = 0.0f;

    }
}
