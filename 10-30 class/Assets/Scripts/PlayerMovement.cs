//#region 19
//using Photon.Pun;
//using UnityEngine;

//// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
//public class PlayerMovement : MonoBehaviourPun
//{
//    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
//    public float rotateSpeed = 180f; // 좌우 회전 속도

//    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터
//    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
//    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디

//    private void Start()
//    {
//        // 사용할 컴포넌트들의 참조를 가져오기
//        playerInput = GetComponent<PlayerInput>();
//        playerRigidbody = GetComponent<Rigidbody>();
//        playerAnimator = GetComponent<Animator>();
//    }

//    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
//    private void FixedUpdate()
//    {
//        // 로컬 플레이어만 직접 위치와 회전을 변경 가능
//        if (!photonView.IsMine)
//        {
//            return;
//        }

//        // 회전 실행
//        Rotate();
//        // 움직임 실행
//        Move();

//        // 입력값에 따라 애니메이터의 Move 파라미터 값을 변경
//        playerAnimator.SetFloat("Move", playerInput.move);
//    }

//    // 입력값에 따라 캐릭터를 앞뒤로 움직임
//    private void Move()
//    {
//        // 상대적으로 이동할 거리 계산
//        Vector3 moveDistance =
//            playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
//        // 리지드바디를 통해 게임 오브젝트 위치 변경
//        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
//    }

//    // 입력값에 따라 캐릭터를 좌우로 회전
//    private void Rotate()
//    {
//        // 상대적으로 회전할 수치 계산
//        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
//        // 리지드바디를 통해 게임 오브젝트 회전 변경
//        playerRigidbody.rotation =
//            playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);
//    }
//}
//#endregion


#region 14

using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도

    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트

    CharacterController character;
    Vector3 movement;
    float gravity = -9.8f;
    private void Start()
    {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();

    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    private void FixedUpdate()
    {
        // 회전 실행
        Rotate();
        // 움직임 실행

        Move();
        // 입력값에 따라 애니메이터의 Move 파라미터 값을 변경
        if (playerInput.move != 0)
        {
            playerAnimator.SetFloat("Move", playerInput.move);

        }
        else if (playerInput.rotate != 0)
        {
            playerAnimator.SetFloat("Move", playerInput.rotate);

        }

    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move()
    {

        float deltaX = playerInput.rotate;
        float deltaZ = playerInput.move;

        movement = new Vector3(deltaX, 0, deltaZ) * Time.deltaTime;
        movement.y = gravity;

        character.Move(movement * moveSpeed);




    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate()
    {
        // 상대적으로 회전할 수치 계산
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray , out hit))
        {
            //레이가 맞은곳에서 캐릭터의 위치를빼면 캐릭터에서 마우스로 향하는 방향을 알수있음
            //단 레이가 맞은곳의 y좌표는 캐릭터의 y좌표로함 안그러면 캐릭터의 위아래방향도 인식되어 캐릭터가 기울어질수있음
            Vector3 mouseDir = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
            transform.forward = mouseDir;
            
        }

        
        //transform.localEulerAngles = mousePos; 

        // 리지드바디를 통해 게임 오브젝트 회전 변경
        //playerRigidbody.rotation = playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);

        //playerRotate = Input.GetAxis("Mouse X");
        //transform.Rotate(0, playerRotate * rotateSpeed * Time.deltaTime, 0, Space.World);
    }
}

#endregion