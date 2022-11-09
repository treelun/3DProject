using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public RectTransform Hp;
    public RectTransform Mp;
    public RectTransform Sta;

    public GameObject playerData;

    private void FixedUpdate()
    {
        Hp.sizeDelta = new Vector2(playerData.GetComponent<PlayerMove>().Hp, 30);
        Mp.sizeDelta = new Vector2(playerData.GetComponent<PlayerMove>().Mp, 30);
        Sta.sizeDelta = new Vector2(playerData.GetComponent<PlayerMove>().Stamina, 30);
    }
}
