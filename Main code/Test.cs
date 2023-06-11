using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public class Test : MonoBehaviour
    {
        public Camera MainCamera;                                               //�������
        public Vector3 LookAtTarget;                                          //����������Ŀ��
        public float CameraDistance = 6.0F;                                     //������뿴��Ŀ��ľ���
        public float CameraHeight = 10.0F;                                       //������߶�
        public float MainCameraMoveSpeed = 10F;                                  //��������ƶ����ٶ�
        public float waitTime = 0F;                                             //�ȴ�������ƶ����豸������ʱ��
        public float CmaeraOffset = 1.0F;                                       //�������ƫ��

        private Vector3 LookAtTargetPosition;
        private Vector3 LookAtTargetPosition2;
        private Quaternion LookAtTargetRotation;                                //����Ŀ�꣬����ת
        private Vector3 _MainCameraOriginalPosition;                            //���������ԭʼλ��

        public bool IsLookAtAppointTarget = false;                              //�Ƿ���ָ��������
        public bool IsBack = false;

        public IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1F);
            //��¼���������ԭʼλ��
            if (MainCamera != null)
            {
                _MainCameraOriginalPosition = new Vector3(MainCamera.transform.localPosition.x, MainCamera.transform.localPosition.y, MainCamera.transform.localPosition.z);
            }

            //_MainCameraOriginalPosition = MainCamera.transform.position;
            //LookAtTargetPosition = LookAtTarget.position + new Vector3(0, CameraHeight, -CameraDistance);
            //LookAtTargetRotation = Quaternion.LookRotation(LookAtTarget.position - MainCamera.transform.position);
        }

        private void FixedUpdate()
        {
            if (IsLookAtAppointTarget == true)
            {
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, LookAtTargetPosition, Time.deltaTime * MainCameraMoveSpeed);
                //if ((LookAtTargetPosition.x - MainCamera.transform.position.x) <= 0.01f)
                //{
                //    MainCamera.transform.position = LookAtTargetPosition;
                //}
                MainCamera.orthographicSize = Mathf.Lerp(MainCamera.orthographicSize, 40f, Time.deltaTime * MainCameraMoveSpeed);
                MainCamera.transform.LookAt(LookAtTarget);

                if (Mathf.Abs(40f - MainCamera.orthographicSize) <= 0.01f)
                {
                    MainCamera.orthographicSize = 40f;
                    IsLookAtAppointTarget = false;
                }
            }
            if (IsBack == true)
            {
                MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, LookAtTargetPosition, Time.deltaTime * MainCameraMoveSpeed);
                MainCamera.orthographicSize = Mathf.Lerp(MainCamera.orthographicSize, 128f, Time.deltaTime * MainCameraMoveSpeed);
                MainCamera.transform.rotation = Quaternion.Euler(19.31f, -24.7f, 3.5f);
                if (Mathf.Abs(128f - MainCamera.orthographicSize) <= 0.01f)
                {
                    MainCamera.orthographicSize = 128f;
                    IsBack = false;
                }
                //StartCoroutine(Stop(waitTime));
            }
        }
        public void LookAtAppointTarget()
        {

            if (LookAtTarget != null)
            {
                LookAtTargetPosition = new Vector3(125.0f, 173.0f-50.0f, -334.0f);
                IsLookAtAppointTarget = true;

            }
            else
            {
                Debug.LogError(GetType() + "/LookAtAppointTarget()/��������岻���ڣ����飡����");
            }


        }

        //public void ReturnOriginalPosition()
        //{
        //    LookAtTargetPosition2 = new Vector3(_MainCameraOriginalPosition.x, _MainCameraOriginalPosition.y, _MainCameraOriginalPosition.z);
        //    MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, LookAtTargetPosition2, Time.deltaTime * MainCameraMoveSpeed);
        //    MainCamera.orthographicSize = Mathf.Lerp(MainCamera.orthographicSize, 128f, Time.deltaTime * MainCameraMoveSpeed);
        //    if (Mathf.Abs(128f - MainCamera.orthographicSize) <= 0.01f)
        //    {
        //        MainCamera.orthographicSize = 128f;
        //    }
        //}
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
    }
}

