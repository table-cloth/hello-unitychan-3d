using UnityEngine;
using System.Collections;
using UnityEditorInternal;

/// <summary>
/// Animation util.
/// </summary>
public class AnimUtil {

    /// <summary>
    /// Gets the length of the animation clip.
    /// </summary>
    /// <returns>The animation clip length.
    /// [NOTE] Animation speed is not considered.</returns>
    /// <param name="animator">Animator.</param>
    /// <param name="animationName">Animation name.</param>
    public static float GetAnimationClipLength(Animator animator, string animationName)
    {
        AnimationClip animationClip = GetAnimationClip(animator, animationName);
        return animationClip.length;
    }

    /// <summary>
    /// Gets the animation clip.
    /// </summary>
    /// <returns>The animation clip.</returns>
    /// <param name="animator">Animator.</param>
    /// <param name="animationName">Animation name.</param>
    public static AnimationClip GetAnimationClip(Animator animator, string animationName)
    {
        RuntimeAnimatorController rac = animator.runtimeAnimatorController;
        AnimationClip animationClip =
            System.Array.Find<AnimationClip>(
                rac.animationClips,
                (AnimationClip) => AnimationClip.name.Equals(animationName));

        if (animationClip == null)
        {
            Debug.LogError("Animation clip is null : " + animationName);
        }
        return animationClip;
    }

}
