using System.Collections;
using UnityEngine;

namespace SCD.Spells.Helpers
{
    public static class AnimationStaticMethods
    {
        public static IEnumerator CO_PlayAnimation(Animator animator, string animationParameter, string animationName, float animationLengthModifier = 0)
        {
            float animationDuration = GetAnimationDuration(animator, animationName);
            animator.SetBool(animationParameter, true);
            yield return new WaitForSeconds(animationDuration + animationLengthModifier);
            animator.SetBool(animationParameter, false);
        }

        public static float GetAnimationDuration(Animator animator, string animationName)
        {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            foreach (AnimationClip clip in clips)
            {
                if (clip.name == animationName)
                    return clip.length;
            }
            return 0f;
        }
    }
}
