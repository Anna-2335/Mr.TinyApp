using System;

using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; } 

    public event EventHandler <OnSelectedVisualChangedEventArgs> OnSelectedVisualChanged;
    public class OnSelectedVisualChangedEventArgs : EventArgs
    {
        public ChairInteraction selectedVisual;
    }


    [SerializeField] private float rotateSpeed = 9f;
    [SerializeField] private float moveSpeed = 15f;

    [SerializeField] private GameInput gameInput;
    //[SerializeField] private GameInput chairLayerMask;

    private bool isWalking;
    private Vector3 lastInteractDir;
    private ChairInteraction selectedVisual;


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one Player Instance");
        }
        Instance = this;
    }
    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }
    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteraction()
    {

        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;


        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }

        float interactDistance = 2f;
       if( Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance))
        {
            if(raycastHit.transform.TryGetComponent(out ChairInteraction chairInteraction))
            {
                //has chair interaction

                if (chairInteraction != selectedVisual)
                {
                    SetSelectedVisual (chairInteraction);

                }
               // chairInteraction.Interact();
            }
            else
            {
                SetSelectedVisual(null); 

            }
        }
       
        else
        {
            SetSelectedVisual(null);
        }
    }

    private void HandleMovement()
    {

            Vector2 inputVector = gameInput.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

        
            //rotates the character when idle on wall

            if (inputVector != Vector2.zero)
            {
                Vector3 lookDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;
                transform.forward = Vector3.Slerp(transform.forward, lookDir, Time.deltaTime * rotateSpeed);
            }

            float moveDistance = moveSpeed * Time.deltaTime;
            float playerRadius = 1.2f;
            float playerHeight = 2f;
            bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

            if (!canMove)
            {
                // Cannot move towards moveDir
                //Attempt onyl X movement. bc when moving in slant it doesnt move

                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
                canMove = moveDir.x !=0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirX;
                }
                else
                {
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                    canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                    if (canMove)
                    {
                        moveDir = moveDirZ;
                    }
                    else
                    {
                        //cant move in any direction
                    }
                }
            }
            if (canMove)
            {
                transform.position += moveDir * moveDistance;
            }



            isWalking = moveDir != Vector3.zero;

            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }
    private void SetSelectedVisual(ChairInteraction selectedVisual)
    {
        this.selectedVisual = selectedVisual;

        OnSelectedVisualChanged?.Invoke(this, new OnSelectedVisualChangedEventArgs
        {
            selectedVisual = selectedVisual
        });
    }

    }

