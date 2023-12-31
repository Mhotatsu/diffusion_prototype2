﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using TMPro;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos.EyeTracking
{
    /// <summary>
    /// Destroys the game object when selected and optionally plays a sound or animation when destroyed.
    /// </summary>
    [RequireComponent(typeof(EyeTrackingTarget))]
    [AddComponentMenu("Scripts/MRTK/Examples/HitBehaviorDestroyOnSelect")]
    public class HitBehaviorDestroyOnSelect : MonoBehaviour
    {
        [Tooltip("Visual effect (e.g., particle explosion or animation) that is played when a target is selected.")]
        [SerializeField]
        private GameObject visualFxTemplate_OnHit = null;

        [Tooltip("Audio clip that is played when a target is selected.")]
        [SerializeField]
        private AudioClip audioFx_CorrectTarget = null;

        [Tooltip("Audio clip that is played when a wrong target is selected.")]
        [SerializeField]
        private AudioClip audioFx_IncorrectTarget = null;

        [Tooltip("Manually indicate whether this is an incorrect target.")]
        [SerializeField]
        private bool is_a_valid_target = true;

        [Tooltip("Associated TargetGridIterator to check whether the currently selected target is the correct one.")]
        [SerializeField]

        //[SerializeField] TextMeshProUGUI resultText;

        private TargetGroupIterator targetIterator = null;


        private EyeTrackingTarget myEyeTrackingTarget = null;

        float elapsedTime;
        public static bool counter_flag = true;
        public GameObject ResultText;
  


        private void Start()
        {
            myEyeTrackingTarget = this.GetComponent<EyeTrackingTarget>();
            if (myEyeTrackingTarget != null) // Shouldn't be null since we use RequireComponent(), but just to be sure.
            {
                myEyeTrackingTarget.OnSelected.AddListener(TargetSelected);
                
            }
        }

        void Update()
        {
            //Debug.Log(Time.time);
            
 
            if (counter_flag == true)
            {
                elapsedTime += Time.deltaTime;
                
            }
        }

        /// <summary>
        /// Internal audio source associated with the game object.
        /// </summary>
        private AudioSource audioSource;

        private void SetUpAudio()
        {
            audioSource = gameObject.EnsureComponent<AudioSource>();

            audioSource.playOnAwake = false;
            audioSource.enabled = true;
        }

        /// <summary>
        /// Play given audio clip.
        /// </summary>
        private float PlayAudioOnHit(AudioClip audioClip)
        {
            // Set up audio source if necessary
            SetUpAudio();

            // Play the given audio clip
            float audiocliplength = 0;
            if ((audioSource != null) && (audioClip != null))
            {
                audioSource.clip = audioClip;
                audioSource.PlayOneShot(audioSource.clip);
                audiocliplength = audioSource.clip.length;
            }
            return audiocliplength;
        }

        /// <summary>
        /// Show given GameObject when target is selected. 
        /// </summary>
        private void PlayAnimationOnHit()
        {
            if (visualFxTemplate_OnHit != null)
            {
                GameObject visfx = Instantiate(visualFxTemplate_OnHit, transform.position, transform.rotation);
                visfx.SetActive(true);
                Destroy(visfx, 2);
            }
        }

        public void TargetSelected()
        {
            if (!is_a_valid_target)
            {
                PlayAudioOnHit(audioFx_IncorrectTarget);
                return;
            }

            if (!HandleTargetGridIterator())
            {
                return;
            }

            // Play audio clip
            float audiocliplength = PlayAudioOnHit(audioFx_CorrectTarget);

            // Play animation
            PlayAnimationOnHit();

            // Destroy target
            gameObject.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, audiocliplength);
            Debug.Log("選択された");
            //Debug.Log(this.gameObject);
            if(this.gameObject.name == "target_x"+flourDeployment.TargetPosition.x+"_y"+flourDeployment.TargetPosition.y+"_z"+flourDeployment.TargetPosition.z)
            {
                Debug.Log(this.gameObject +"計測結果： " + (elapsedTime).ToString());
                string timeresult =  (flourDeployment.TargetPosition +"計測結果： " + (elapsedTime).ToString());
                Gettext.SetText(timeresult);
                //GameObject resultText = GameObject.Find("ResultText");
                //Debug.Log(resultText);
                //resultText.GetComponent<TextMeshPro>().text = "あ";

            }

        }

        /// <summary>
        /// Check whether the selected target is the intended one based on the referenced 'targetIterator' object.
        /// </summary>
        private bool HandleTargetGridIterator()
        {
            if (targetIterator != null)
            {
                if ((targetIterator.PreviousTarget != null) && (targetIterator.PreviousTarget.name == name))
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            PlayAudioOnHit(audioFx_IncorrectTarget);
            return false;
        }
    }
}