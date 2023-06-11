using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIFrame
{
    public class Test2 : Test
    {
        private BtnBackBan btnBackBan;//���ذ�ť

        public Camera MainCamera1;
        private Interaction interaction;
        private GrassSpawn grassSpawn;
        public Vector3 centerPoint;
        private void Start()
        {
            base.MainCamera = MainCamera1;
            StartCoroutine(base.Start());

            btnBackBan = FindObjectOfType<BtnBackBan>();
        }
        //private void UpDate()
        //{
        //    birdController = FindObjectOfType<BirdController>();
        //    centerPoint = birdController.centerPoint;
        //}

        //����Բ�򷽷�
        public void CloseShere()
        {
            interaction = FindObjectOfType<Interaction>();
            centerPoint = interaction.TreePos;
            base.LookAtTarget = centerPoint;
            base.LookAtAppointTarget();
            StartCoroutine(ExecuteFadeOutAfterDelay());
        }
        public void CloseBee()
        {
            grassSpawn = FindObjectOfType<GrassSpawn>();
            centerPoint = grassSpawn.TreePos;
            base.LookAtTarget = centerPoint;
            base.LookAtAppointTarget();
            StartCoroutine(ExecuteFadeOutAfterDelay());
        }

        public void ReturnToOriginalPositionAfterDelay()
        {
            base.ReturnOriginalPosition();
            BtnBackdontshow();
            // �������б��Ϊ"Animal"�Ķ���
            GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
            foreach (GameObject animal in animals)
            {
                Destroy(animal);
            }
        }
        private IEnumerator ExecuteFadeOutAfterDelay()
        {
            yield return new WaitForSeconds(5f);
            btnBackBan.RunBtn();
        }
        private void BtnBackdontshow()
        {
            btnBackBan.BanBtn();
        }
    }
}

