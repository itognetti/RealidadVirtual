using System.Collections;
using UnityEngine;

public class RandomAnimationPlayer : MonoBehaviour
{
    private Animation animationComponent;
    private int numberOfAnimations;
    private WaitForSeconds randomWaitTime;

    void Start()
    {
        animationComponent = GetComponent<Animation>();
        numberOfAnimations = animationComponent.GetClipCount();
        
        StartCoroutine(PlayRandomAnimation());
    }

    IEnumerator PlayRandomAnimation()
    {
        while (true)
        {
            PlayRandom();
            randomWaitTime = new WaitForSeconds(Random.Range(2f, 5f));
            yield return randomWaitTime;
        }
    }

    void PlayRandom()
    {
        int randomAnimationIndex = GetRandomAnimationIndex();
        if (randomAnimationIndex < numberOfAnimations)
        {
            AnimationState randomAnimation = null;
            foreach (AnimationState animState in animationComponent)
            {
                if (randomAnimationIndex == 0)
                {
                    randomAnimation = animState;
                    break;
                }
                randomAnimationIndex--;
            }
            if (randomAnimation != null)
            {
                animationComponent.CrossFade(randomAnimation.name);
            }
        }
    }

    int GetRandomAnimationIndex()
    {
        return Random.Range(0, numberOfAnimations);
    }
}
