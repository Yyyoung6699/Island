/***
*	Title��"����" ��Ŀ
*		���⣺������������ӽ��л�
*	Description��
*		���ܣ�XXX
*	Date��2017
*	Version��0.1�汾
*	Author��Coffee
*	Modify Recoder��
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleUIFrame
{
    public class Test_ViewChange : MonoBehaviour
    {
        public Camera MainCamera;                                               //�������
        public Transform LookAtTarget;                                          //����������Ŀ��
        public float CameraDistance = 6.0F;                                     //������뿴��Ŀ��ľ���
        public float CameraHeight = 3.0F;                                       //������߶�
        public float CmaeraOffset = 1.0F;                                       //�������ƫ��
        public float MainCameraMoveSpeed = 2F;                                  //��������ƶ����ٶ�
        public float waitTime = 0F;                                               //�ȴ�������ƶ����豸������ʱ��


        private Vector3 LookAtTargetPosition;                                  //����Ŀ��ʱ��λ��
        private Quaternion LookAtTargetRotation;                               //����Ŀ�꣬����ת

        public bool IsLookAtAppointTarget = false;                                //�Ƿ���ָ��������
        public bool IsBack = false;

        private Vector3 _MainCameraOriginalPosition;                            //���������ԭʼλ��



        public IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1F);
            //��¼���������ԭʼλ��
            if (MainCamera != null)
            {
                _MainCameraOriginalPosition = new Vector3(MainCamera.transform.localPosition.x, MainCamera.transform.localPosition.y, MainCamera.transform.localPosition.z);
                print("���������ԭʼλ�õ�X=" + _MainCameraOriginalPosition.x);
                print("���������ԭʼλ�õ�Y=" + _MainCameraOriginalPosition.y);
                print("���������ԭʼλ�õ�Z=" + _MainCameraOriginalPosition.z);
                print("���������ԭʼλ�õ�Z=" + _MainCameraOriginalPosition.z);
            }
        }


        private void FixedUpdate()
        {

            if (IsLookAtAppointTarget == true)
            {
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, LookAtTargetPosition, Time.deltaTime * MainCameraMoveSpeed);
                MainCamera.transform.LookAt(LookAtTarget);

                // StartCoroutine(Stop(waitTime));
            }
            if (IsBack == true)
            {
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, LookAtTargetPosition, Time.deltaTime * MainCameraMoveSpeed);

                //StartCoroutine(Stop(waitTime));
            }

        }

        /// <summary>
        /// ���������ָ������ķ���
        /// </summary>
        public void LookAtAppointTarget()
        {

            if (LookAtTarget != null)
            {
                LookAtTargetPosition = new Vector3(LookAtTarget.transform.position.x + CmaeraOffset, LookAtTarget.transform.position.y + CameraHeight, LookAtTarget.transform.position.z + CameraDistance);
                IsLookAtAppointTarget = true;

            }
            else
            {
                Debug.LogError(GetType() + "/LookAtAppointTarget()/��������岻���ڣ����飡����");
            }


        }

        //���������ԭʼλ��
        public void ReturnOriginalPosition()
        {
            LookAtTargetPosition = new Vector3(_MainCameraOriginalPosition.x, _MainCameraOriginalPosition.y, _MainCameraOriginalPosition.z);
            IsBack = true;

        }

        IEnumerator Stop(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            if (IsLookAtAppointTarget == true)
            {
                IsLookAtAppointTarget = false;
                print("IsLookAtAppointTarget=" + IsLookAtAppointTarget);
            }
            if (IsBack == true)
            {
                IsBack = false;
                print("IsBack=" + IsBack);
            }

        }



    }//class_end
}