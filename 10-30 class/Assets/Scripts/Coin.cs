#region 19
using Photon.Pun;
using UnityEngine;

// 게임 점수를 증가시키는 아이템
public class Coin : MonoBehaviourPun, IItem
{
    public int score = 200; // 증가할 점수

    public void Use(GameObject target)
    {
        // 게임 매니저로 접근해 점수 추가
        GameManager.instance.AddScore(score);
        // 모든 클라이언트에서의 자신을 파괴
        PhotonNetwork.Destroy(gameObject);
    }
}
#endregion

//#region 17
//using UnityEngine;

//// 게임 점수를 증가시키는 아이템
//public class Coin : MonoBehaviour, IItem
//{
//    public int score = 200; // 증가할 점수

//    public void Use(GameObject target)
//    {
//        // 게임 매니저로 접근해 점수 추가
//        GameManager.instance.AddScore(score);
//        // 사용되었으므로, 자신을 파괴
//        Destroy(gameObject);
//    }
//}
//#endregion