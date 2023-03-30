using UnityEngine;
using DG.Tweening;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float _rotateOnXDegree = 50f;
    [SerializeField] private float _moveSpeed = 10f;

    private const float ROTATEDURATION = 1.5f, DEFAULTXROTATION = -90f;

    private enum MoveDirection
    {
        up,
        down
    };

    private delegate void MoveDelegate(MoveDirection moveDirection);
    private event MoveDelegate OnMove;

    private delegate void MoveEndedDelegate();
    private event MoveEndedDelegate OnMoveEnded;

    private void Awake()
    {
        OnMove += Rotate;
        OnMove += Move;

        OnMoveEnded += ResetRotation;
    }

    private void Rotate(MoveDirection moveDirection)
    {
        switch (moveDirection)
        {
            case MoveDirection.up:
                transform.DORotateQuaternion(Quaternion.Euler(DEFAULTXROTATION - _rotateOnXDegree * 2f, transform.rotation.y, transform.rotation.z), ROTATEDURATION);
                break;

            case MoveDirection.down:
                transform.DORotateQuaternion(Quaternion.Euler(DEFAULTXROTATION + _rotateOnXDegree, transform.rotation.y, transform.rotation.z), ROTATEDURATION);
                break;
        }
    }

    private void ResetRotation()
    {
        transform.DORotateQuaternion(Quaternion.Euler(DEFAULTXROTATION, transform.rotation.y, transform.rotation.z), ROTATEDURATION);
    }

    private void Move(MoveDirection moveDirection)
    {
        switch (moveDirection)
        {
            case MoveDirection.up:
                transform.Translate(Vector3.up * 2f * _moveSpeed * Time.deltaTime, Space.World);
                break;

            case MoveDirection.down:
                transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime, Space.World);
                break;
        }
    }

    private void Update()
    {
        OnMove?.Invoke(MoveDirection.down);

        if(Input.touchCount > 0)
        {
            OnMove?.Invoke(MoveDirection.up);

            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Ended)
                {
                    OnMoveEnded?.Invoke();
                }
            }
        }
    }

    private void OnDestroy()
    {
        OnMove -= Rotate;
        OnMove -= Move;

        OnMoveEnded -= ResetRotation;
    }
}
