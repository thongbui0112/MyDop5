using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LeaderBoard : MonoBehaviour {
    [SerializeField] GameObject leaderBoardObj;
    [SerializeField] GameObject content, scroll;
    [SerializeField] Button leaderBoardButton, exitButton;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] List<Player> playerList = new List<Player>();
    [SerializeField] TMP_Text starCount;    
    private void Awake() {
       // ReadData();
    }
    private void Start() {
        this.leaderBoardButton.onClick.AddListener(LeaderBoardButton);
        this.exitButton.onClick.AddListener(ExitButton);
        this.leaderBoardObj.SetActive(false);
    }




    public void LeaderBoardButton() {
        CreateLeaderBoard();
        this.leaderBoardObj.SetActive(true);
        this.scroll.GetComponent<ScrollRect>().normalizedPosition = Vector3.one;
        FindObjectOfType<EraseController>().PlayingGame = false;
    }

    public void ExitButton() {
        foreach(Transform obj in content.transform) {
            Destroy(obj.gameObject);
        }
        this.leaderBoardObj.SetActive(false);
        FindObjectOfType<EraseController>().PlayingGame = true;
    }

    public void CreateLeaderBoard() {

        CreatePlayer();

        for(int i = 0; i < 99; i++) {
            GameObject playerObj = Instantiate(playerPrefab, content.transform);
            Player player = this.playerList[i];
            playerObj.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = player.order;
            playerObj.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = player.namee;
            playerObj.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = player.star;
        }
        GameObject playerO = Instantiate(playerPrefab, content.transform);
        playerO.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = "100";
        playerO.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = "Player";
        playerO.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = (LevelController.Instance.CurrentLevel * 3 - 3).ToString();

        this.starCount.text = (LevelController.Instance.CurrentLevel * 3 - 3).ToString();
    }

    public void CreatePlayer() {
        int count = 300;
        for(int i = 0; i < 99; i++) {
            int countName = Random.Range(4, 7);
            string listName = "qwertyuiopasdfghjklzxcvbnm1234567890";
            string namePlayer = string.Empty;
            for(int j = 0; j < countName; j++) {
                namePlayer += listName[Random.Range(0, listName.Length)];
            }
            int star = count * 3;
            count--;
            Player player = new Player((i+1).ToString(),namePlayer,star.ToString());
            this.playerList.Add(player);
           // WriteData((i + 1).ToString(), namePlayer, star.ToString());
        }
    }

    public void WriteData(string order, string name, string star) {
        string filePath = "Assets/data.txt";

        string data = order + "," + name + "," + star;

        if(File.Exists(filePath)) {
            File.AppendAllText(filePath, data + "\n");
        }
        else {
            File.WriteAllText(filePath, data + "\n");
        }
    }

}
