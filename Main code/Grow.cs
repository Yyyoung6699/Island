using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public float growSpeed = 0.2f;



    private int sizeChange;
    private Vector3 currentScale;
    private Vector3 currentVelocity = Vector3.zero;
    
    AudioSource audioS;
    public AudioClip leaveAudio;

    public ParticleSystem leaveParticle;//树叶粒子


    private void Awake()
    {
        float randomSize = Random.Range(0.5f, 1.5f);
        DontDestroyOnLoad(this);
        currentScale = transform.localScale * randomSize;
    }
    void Start()
    {

        transform.localScale = Vector3.zero;
        sizeChange = 0;
        audioS = GetComponent<AudioSource>();
    }
    private void Update()
    {
        SizeChange();

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    Destroy(gameObject);
        //}
    }
    private void SizeChange()
    {
        switch (sizeChange)
        {
            case 0:
                this.transform.localScale = Vector3.SmoothDamp(transform.localScale, currentScale, ref currentVelocity, growSpeed);
            if ((currentScale.x - transform.localScale.x) <= 0.01f)
                {
                transform.localScale = new Vector3(currentScale.x, currentScale.y, currentScale.z);
                    sizeChange = 0;
                }
                break;
                
            case 1://点击以后放大然后马上缩小
                this.transform.localScale = Vector3.SmoothDamp(transform.localScale, currentScale * 1.2f, ref currentVelocity, growSpeed);
                if ((currentScale.x * 1.2f - transform.localScale.x) <= 0.01f)
                {
                    this.transform.localScale = Vector3.SmoothDamp(transform.localScale, currentScale / 1.2f, ref currentVelocity, growSpeed);
                    sizeChange = 0;
                }
                    break;


        }
    }
    public void PlayParticleEffect()
    {
        audioS.clip = leaveAudio;
        audioS.Play();
        leaveParticle.Play();
        sizeChange = 1;
        SizeChange();
    }


}
