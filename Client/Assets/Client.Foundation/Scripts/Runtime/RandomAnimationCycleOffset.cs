using UnityEngine;

namespace Client.Foundation
{
    public sealed class RandomAnimationCycleOffset : StateMachineBehaviour
    {
        private bool _executed;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_executed)
            {
                return;
            }

            _executed = true;

            animator.Play(stateInfo.fullPathHash, layerIndex, Random.value);
        }
    }
}
