
using UnityEngine;
[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public string request;
    public int numberOfItem;
    public string[] nameItem;
    public bool[] state;
    public bool[] eraseable;
    public Sprite[] sprite;
    public int[] sortingOrder;
    public Vector2[] pos;
    public Quaternion[] rot;
    public Vector3[] scale;
}


