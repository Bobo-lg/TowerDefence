using System.Collections;
using System.Collections.Generic;
using TZY.Tool;
using UnityEngine;

namespace TZY.Tool
{
    public static class ExpandClass
    {
        /// <summary>
        /// ����Ŀ�귽����Y��Ϊ����
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="target"></param>
        /// <param name="timer">ƽ��ʱ��(����ǵ���ĳ������������ôֵ�������100���ϡ�)</param>
        public static void Look(this Transform transform, Vector3 target, float timer)
        {
            var direction = (target - transform.position).normalized;
            direction.y = 0f;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, DevelopmentTools.UnTetheredLerp(timer));
        }

        /// <summary>
        /// ��鵱ǰ����Ƭ���Ƿ���ָ��Tag
        /// </summary>
        /// <param name="animator"></param>
        /// <param name="tagName"></param>
        /// <param name="indexLayer"></param>
        /// <returns></returns>
        public static bool AnimationAtTag(this Animator animator, string tagName, int indexLayer = 0)
        {
            return animator.GetCurrentAnimatorStateInfo(indexLayer).IsTag(tagName);
        }
    }
}