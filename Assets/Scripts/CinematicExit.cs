using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicExit : StateMachineBehaviour
{
    private readonly string scene = "MovementScene";
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetButtonDown("Fire1"))
            SceneManager.LoadScene(scene);
    }

   
}