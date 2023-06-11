/***
*	Title："测试" 项目
*		主题：测试摄像机的视角切换
*	Description：
*		功能：XXX
*	Date：2017
*	Version：0.1版本
*	Author：Coffee
*	Modify Recoder：
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleUIFrame
{
    public class Test_ViewChange : MonoBehaviour
    {
        public Camera MainCamera;                                               //主摄像机
        public Transform LookAtTarget;                                          //摄像机看向的目标
        public float CameraDistance = 6.0F;                                     //摄像机与看向目标的距离
        public float CameraHeight = 3.0F;                                       //摄像机高度
        public float CmaeraOffset = 1.0F;                                       //摄像机的偏移
        public float MainCameraMoveSpeed = 2F;                                  //主摄像机移动的速度
        public float waitTime = 0F;                                               //等待摄像机移动到设备附近的时间


        private Vector3 LookAtTargetPosition;                                  //看向目标时的位置
        private Quaternion LookAtTargetRotation;                               //看向目标，且旋转

        public bool IsLookAtAppointTarget = false;                                //是否看向指定的物体
        public bool IsBack = false;

        private Vector3 _MainCameraOriginalPosition;                            //主摄像机的原始位置



        public IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1F);
            //记录主摄像机的原始位置
            if (MainCamera != null)
            {
                _MainCameraOriginalPosition = new Vector3(MainCamera.transform.localPosition.x, MainCamera.transform.localPosition.y, MainCamera.transform.localPosition.z);
                print("主摄像机的原始位置的X=" + _MainCameraOriginalPosition.x);
                print("主摄像机的原始位置的Y=" + _MainCameraOriginalPosition.y);
                print("主摄像机的原始位置的Z=" + _MainCameraOriginalPosition.z);
                print("主摄像机的原始位置的Z=" + _MainCameraOriginalPosition.z);
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
        /// 摄像机看向指定物体的方法
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
                Debug.LogError(GetType() + "/LookAtAppointTarget()/看向的物体不存在，请检查！！！");
            }


        }

        //摄像机返回原始位置
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