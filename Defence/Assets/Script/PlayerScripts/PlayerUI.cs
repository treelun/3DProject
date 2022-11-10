using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public CharaterData playerData;
    [SerializeField] Slider HpBar;
    [SerializeField] Slider MpBar;
    [SerializeField] Slider StaBar;

    public PlayerMove character;


    float maxHp;
    float startHp;

    float maxMp;
    float startMp;
    
    float maxSta;
    float startSta;


    private void Start()
    {
        maxHp = character.maxHp;
    }

    private void Update()
    {
        HpBar.value = playerData.startingHp / maxHp;
    }

}
