using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]

    public class meditation_contr : MonoBehaviour
    {
        private CarController m_Car04; // the car
        private int nextUpdate = 1;
        public int the_mode = 300;
        private int eye_switch = 0;
        private int master_lock = 0;
        public int meditation_speed_level = 50;



        private void Awake()
        {
            // get the car type of EEG
            m_Car04 = GetComponent<CarController>();
            the_mode = MAIN1.Select_game_mode;
          //  CarController.the_speed = 10;
        }

        private void FixedUpdate()
        {
            if ((PortS.brain_level_meditation < 100) && (PortS.brain_level_meditation > 90))
            {
                //CarController.the_speed = 4;
            }
            if ((PortS.brain_level_meditation < 90) && (PortS.brain_level_meditation > 80))
            {
               // CarController.the_speed = 7;
            }
            if (PortS.brain_level_meditation < 80)
            {
               // CarController.the_speed = 10;
            }
            if (the_mode == 4)
            {
                if ((PortS.brain_level_meditation) > slider_meditation.Meditationn_speed_level)
                {
                    m_Car04.Move(0, 1, 0, 0);
                    master_lock = 0;
                }
                if ((PortS.brain_level_meditation) < slider_meditation.Meditationn_speed_level)
                {
                    if (master_lock == 0)
                    {
                        m_Car04.Move(0, 0, 0, 0);
                        master_lock = 1;
                    }
                }
            }
        }
    }
}
