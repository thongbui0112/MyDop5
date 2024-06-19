using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EraseController : MonoBehaviour {
    Transform eraseParent;
    Vector3 oldMousePos;
    Transform _cam;

    [SerializeField] GameObject eraserPrefab;
    [SerializeField] bool canClick;
    [SerializeField] bool mousePressed, startErase, finishErase;
    [SerializeField] float minDistacncePerErase;


    [SerializeField] bool eraseable;
    [SerializeField] LayerMask eraseableMask;

    [SerializeField] Sprite mousePressedSprite;
    [SerializeField] GameObject mouseSprite;
    [SerializeField] bool playingGame;
    #region
    public GameObject MouseSprite { get => mouseSprite; set => mouseSprite = value; }
    public bool MousePressed { get => mousePressed; set => mousePressed = value; }
    public bool StartErase { get => startErase; set => startErase = value; }
    public bool FinishErase { get => finishErase; set => finishErase = value; }
    public bool Eraseable { get => eraseable; set => eraseable = value; }
    public bool CanClick { get => canClick; set => canClick = value; }
    public bool PlayingGame { get => playingGame; set => playingGame = value; }
    #endregion

    private void Awake() {
        this.eraseParent = GetComponent<Transform>();
        _cam = GameObject.Find("Main Camera").transform;
    }

    private void Start() {
        this.StartErase = this.FinishErase = this.mousePressed = false;
        this.canClick = true;
        this.PlayingGame = true;
    }


    private void Update() {

        Vector2 currentMousePos = InputMouse.Instance.MousePosition;
        this.Eraseable = Physics2D.CircleCast(currentMousePos, 1f, Vector2.zero, 0f, this.eraseableMask);

        if(InputMouse.Instance.LeftMouseButtonDown && this.canClick) {
            this.StartErase = true;
            this.finishErase = false;
        }
        else if(InputMouse.Instance.LeftMouseButtonUp && this.canClick) {
            this.startErase = false;
            this.FinishErase = true;
        }
        if(startErase && playingGame)
            this.MouseSprite.GetComponent<SpriteRenderer>().sprite = this.mousePressedSprite;
        if(!playingGame || finishErase)
            this.MouseSprite.GetComponent<SpriteRenderer>().sprite = null;

        if(this.StartErase)
            this.MouseSprite.transform.position = currentMousePos;
        if(this.playingGame)
            if(this.StartErase && this.Eraseable && this.canClick && this.PlayingGame) {
                if(Vector2.Distance(this.oldMousePos, currentMousePos) >= this.minDistacncePerErase) {
                    GameObject erase = Instantiate(this.eraserPrefab, currentMousePos, this.mouseSprite.transform.rotation);
                    erase.transform.parent = this.eraseParent;
                }
            }

        this.oldMousePos = currentMousePos;
    }

    public IEnumerator SetNewLevel() {
        yield return new WaitForSeconds(0.1f);
        this.StartErase = this.FinishErase = this.mousePressed = false;
        this.canClick = true;
    }


    public void DestroyErases() {
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }
    }


}
