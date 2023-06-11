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

        private Button BtnSphere;                                                //查看圆球按钮
        private Button BtnCube;                                                  //查看Cube按钮

        private void Awake()
        {
            //RigisterBtn1();
        }
        private void Start()
        {
            base.MainCamera = MainCamera1;
            StartCoroutine(base.Start());
        }


        //靠近圆球方法
        public void CloseShere()
        {

            base.LookAtTarget = sphere;
            base.LookAtAppointTarget();

        }

        //靠近Cube方法
        public void CloseCube()
        {

            base.LookAtTarget = cube;
            base.LookAtAppointTarget();

        }


    }
}