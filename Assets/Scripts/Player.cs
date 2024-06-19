using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string order;
    public string namee;
    public string star;

    //private void Awake() {
    //    transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = order.ToString();
    //    transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = namee.ToString();
    //    transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = star.ToString();
    //}

    public Player(string order, string namee,string star) {
        this.order = order;
        this.namee = namee;
        this.star = star;   
    }
}
