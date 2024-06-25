using UnityEngine;

public class ChaseState : StateMachineBehaviour
{
    Transform target;
    public float speed = 3;
    Transform borderCheck;

    // OnStateEnter được gọi khi bắt đầu một chuyển tiếp và máy trạng thái bắt đầu đánh giá trạng thái này
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy đối tượng với thẻ 'Player'");
        }

        Zombie zombie = animator.GetComponent<Zombie>();
        if (zombie != null)
        {
            borderCheck = zombie.borderCheck;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy thành phần 'Zombie' trên đối tượng Animator");
        }
    }

    // OnStateUpdate được gọi trong mỗi khung Update giữa OnStateEnter và OnStateExit
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (target == null || borderCheck == null) return;

        Vector2 newPos = new Vector2(target.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, newPos, speed * Time.deltaTime);

        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
        {
            animator.SetBool("isChasing", false);
        }

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 1.5f)
        {
            animator.SetBool("isAttacking", true);
        }
    }

    // OnStateExit được gọi khi một chuyển tiếp kết thúc và máy trạng thái kết thúc đánh giá trạng thái này
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
