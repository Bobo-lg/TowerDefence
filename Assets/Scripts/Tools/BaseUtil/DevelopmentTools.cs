using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZY.Tool
{
    public class DevelopmentTools
    {

        /// <summary>
        /// ����֡��Ӱ���Lerp
        /// </summary>
        /// <param name="time">ƽ��ʱ��(��������Ϊ����10��ֵ)</param>
        public static float UnTetheredLerp(float time = 10f)
        {
            return 1 - Mathf.Exp(-time * Time.deltaTime);
        }

        /// <summary>
        /// ȡĿ�귽��(����һ������)
        /// </summary>
        /// <param name="target">Ŀ��</param>
        /// <param name="self">����</param>
        /// <returns></returns>
        public static Vector3 DirectionForTarget(Transform target, Transform self)
        {
            return (self.position - target.position).normalized;
        }

        /// <summary>
        /// ������Ŀ��֮��ľ���
        /// </summary>
        /// <param name="target"></param>
        /// <param name="self"></param>
        /// <returns></returns>
        public static float DistanceForTarget(Transform target, Transform self)
        {
            return Vector3.Distance(self.position, target.position);
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        /// <param name="currentDirection">��ǰ�ƶ�����</param>
        /// <param name="targetDirection">Ŀ���ƶ�����</param>
        /// <returns></returns>
        public static float GetDeltaAngle(Transform currentDirection, Vector3 targetDirection)
        {
            //��ǰ��ɫ����ĽǶ�
            float angleCurrent = Mathf.Atan2(currentDirection.forward.x, currentDirection.forward.z) * Mathf.Rad2Deg;
            //Ŀ�귽��ĽǶ�Ҳ����ϣ����ɫת��ȥ���Ǹ�����ĽǶ�
            float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;

            return Mathf.DeltaAngle(angleCurrent, targetAngle);
        }

        /// <summary>
        /// ���㵱ǰ������Ŀ�귽��֮��ļн�
        /// </summary>
        /// <param name="target"></param>
        /// <param name="self"></param>
        /// <returns></returns>
        public static float GetAngleForTargetDirection(Transform target, Transform self)
        {
            return Vector3.Angle(((self.position - target.position).normalized), self.forward);
        }

        /// <summary>
        /// ����һ��ֵ���߶�����-360-360֮��
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float ClampValueOn360(float f)
        {
            f %= 360f;
            if (f < 0)
                f += 360;

            return f;
        }

        /// <summary>
        /// ����һ��ֵ���߶�����-180-180֮��
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static float ClampValueOn180(float f)
        {
            f = (f + 180f) % 360f - 180f;

            if (f < -180)
                f += 360;

            return f;
        }

        /// <summary>
        /// �ӵ�ǰλ���ƶ���Ŀ��λ��
        /// ���㵱ǰ���Ŀ���֮���λ�ã��ƶ�������maxDistanceDeltaָ���ľ��롣
        /// </summary>
        /// <param name="target"></param>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Vector3 TargetPositionOffset(Transform target, Transform self, float time)
        {
            var pos = target.transform.position;
            return Vector3.MoveTowards(self.position, pos, UnTetheredLerp(time));
        }

        /// <summary>
        /// ��ӡ��־
        /// </summary>
        /// <param name="message"></param>
        public static void WTF(object message)
        {
            Debug.LogFormat($"��־����:<color=#ff0000> --->   {message}   <--- </color>");
        }
    }
}
