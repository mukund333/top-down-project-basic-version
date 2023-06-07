using UnityEngine;

public class ImmortalityStatePlayer : MonoBehaviour
{
    private ColliderController colliderController;
    [SerializeField]  private PlayerStateMachine _stateMachine;
    [SerializeField] private bool isImmortal;


    private void Start()
    {
        colliderController = GetComponent<ColliderController>();
        _stateMachine = GetComponent<PlayerStateMachine>();
    }


    private void Update()
    {
         isImmortal = (_stateMachine.GetCurrentState() == _stateMachine.dashState ||
                           _stateMachine.GetCurrentState() == _stateMachine.knockbackState);

        colliderController.SetColliderEnabled(isImmortal);


    }

   
}
