using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]

    public class Att_Med_Controller : MonoBehaviour
    {
        private CarController m_Car010; // the car
        private int nextUpdate = 1;
        public int the_mode = 300;
        private int eye_switch = 0;
        private int master_lock = 0;
        public int meditation_speed_level = 50;



        private void Awake()
        {
            // get the car type of EEG
            m_Car010 = GetComponent<CarController>();
            the_mode = MAIN1.Select_game_mode;
            //CarController.the_speed = 10;
        }

        private void FixedUpdate()
        {
            if ((PortS.brain_level_meditation < 100) && (PortS.brain_level_meditation > 90))
            {
                if ((PortS.brain_level_attention < 100) && (PortS.brain_level_attention > 90))
                {
                    //CarController.the_speed = 4;
                }
            }
            if ((PortS.brain_level_meditation < 90) && (PortS.brain_level_meditation > 80))
            {
                if ((PortS.brain_level_attention < 90) && (PortS.brain_level_attention > 80))
                {
                   // CarController.the_speed = 7;
                }
            }
            if (PortS.brain_level_meditation < 80)
            {
                if (PortS.brain_level_attention < 80)
                {
                    //CarController.the_speed = 10;
                }
            }
            if (the_mode == 10)
            {
                if (((PortS.brain_level_meditation) > double_Med_Silder.double_Meditation_speed_level) && ((PortS.brain_level_attention) > double_Att_Silder.double_attention_speed_level)) 
                {
                    m_Car010.Move(0, 1, 0, 0);
                    master_lock = 0;
                }
                if (((PortS.brain_level_meditation) < double_Med_Silder.double_Meditation_speed_level) || ((PortS.brain_level_attention) < double_Att_Silder.double_attention_speed_level))
                {
                    if (master_lock == 0)
                    {
                        m_Car010.Move(0, 0, 0, 0);
                        master_lock = 1;
                    }
                }
            }
        }
    }
}
