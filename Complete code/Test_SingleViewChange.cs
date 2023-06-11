//using kernal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleUIFrame
{
    public class Test_SingleViewChange : Test_ViewChange
    {
        public Camera MainCamera1;
        public Transform sphere;
        public Transform cube;

        private Button BtnSphere;                                                //�鿴Բ��ť
        private Button BtnCube;                                                  //�鿴Cube��ť

        private void Awake()
        {
            //RigisterBtn1();
        }
        private void Start()
        {
            base.MainCamera = MainCamera1;
            StartCoroutine(base.Start());
        }


        //����Բ�򷽷�
        public void CloseShere()
        {

            base.LookAtTarget = sphere;
            base.LookAtAppointTarget();

        }

        //����Cube����
        public void CloseCube()
        {

            base.LookAtTarget = cube;
            base.LookAtAppointTarget();

        }


    }
}