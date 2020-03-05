
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]

    public class Game_Pad_control : MonoBehaviour
    {
        private CarController m_Car03; // the car
        private int nextUpdate = 1;
        public int the_mode = 300;
        private int eye_switch = 0;
        private int master_lock = 0;




        private void Awake()
        {
            // get the car type of EEG
            m_Car03 = GetComponent<CarController>();
            the_mode = MAIN1.Select_game_mode;
            if (MAIN1.Select_game_mode == 3)
            {
                transform.position = new Vector3(565.2f, 0f, 40.1f);
            }
          //  CarController.the_speed = 30f;
        }

        private void FixedUpdate()
        {
           // CarController.the_speed = 30f;
            if (the_mode == 3)
            {
                // the cross aofl
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
                float handbrake = CrossPlatformInputManager.GetAxis("Jump");

                m_Car03.Move(h, v, v, handbrake);

#else
            m_Car03.Move007(h, v, v, 0f, speed_cap);
#endif

            }
        }

    }

}
