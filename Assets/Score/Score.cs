using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform player;
    public int scoreSpeed = 1;

    void Update()
    {
        //Debug.Log(((int)(player.position.y / scoreSpeed)).ToString());
        GetComponent<Text>().text = ((int)(player.position.z / scoreSpeed)).ToString();
    }
}
