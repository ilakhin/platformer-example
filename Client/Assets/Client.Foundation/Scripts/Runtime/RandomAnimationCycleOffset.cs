using UnityEngine;

namespace Client.Foundation
{
    // Устанавливает случайную позицию анимации. Используется для вариативности.
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
