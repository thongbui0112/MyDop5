using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : Level
{
    protected override void Awake() {
        base.Awake();
        this.noCheckPoint = new List<Vector2>();
        this.noCheckPointState = new List<bool>();
        StartCoroutine(GetAllNoCheckPoint());
    }

    private void Update() {
        if(this.eraseController.StartErase && this.eraseController.Eraseable && this.eraseController.PlayingGame) {
            CheckPoint();
            NoCheckPoint();
        }
        if(this.eraseController.FinishErase) {
            this.eraseController.FinishErase = false;
            if(this.countCheckPoint >= this.minCheckPointToVictory && this.countNoCheckPoint == 0) {
                this.eraseController.CanClick = false;
                Debug.Log("qua man");
                SetVictoryState();
                VictoryPanel();
            }
            else {
                this.eraseController.DestroyErases();
                ResetCheckPointState();
                ResetNoCheckPointState();
            }
        }
    }



    public override void SetVictoryState() {
        for(int i = 0; i < 2; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        for(int i = 2; i < 3; i++) {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public override void CheckPoint() {
        base.CheckPoint();
    }

    public override void ResetCheckPointState() {
        base.ResetCheckPointState();
    }
}
