
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]

    public class brainControl : MonoBehaviour
    {
        private CarController m_Car01; // the car
        private int nextUpdate = 1;
        public int the_mode = 300;
        private int eye_switch = 0;
        private int the_queue_lock = 0;
        private int queue_count = 0;
        private int master_lock = 0;
        private AudioSource source;
        Queue numbers = new Queue();



        private void Awake()
        {
            // get the car type of EEG
            m_Car01 = GetComponent<CarController>();
            the_mode = MAIN1.Select_game_mode;
            if (MAIN1.Select_game_mode == 1) 
            {
                for (int i = 0; i < 30; i++)
                {
                    numbers.Enqueue(i);
                }   
            }
            source = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            
            int queue_count = numbers.Count;
            if (queue_count > 0)
            {
               // m_Car01.Move007(0, 1, 0, 0, 4);
                // m_Car01.Move(0, 1, 0, 0);
                the_queue_lock = 0;
                EyeSCR.Eyescr_eye_open.text = ((PortS.brain_level_eye_blink).ToString());
            }
            if (the_queue_lock == 0)
            {
                if (queue_count <= 1)
                {
                    source.Play();
                    m_Car01.Move(0, 0, 0, 0);
                    the_queue_lock = 1;
                    EyeSCR.Eyescr_eye_open.text = "NO";
                    master_lock = 1;

                }
            }
            if (Time.time >= nextUpdate)
            {
                nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                queue_update();
            }
        }

        void queue_update()
        {
            queue_count = numbers.Count;
          //  Debug.Log("time in second = " + ((PortS.brain_level_eye_blink).ToString()));
            if ((PortS.brain_level_eye_blink) > 2110)
            {
               eye_blink.matrix.text = "YES";
                if ((queue_count < 10) && (queue_count > 0))
                {
                    if (queue_count < 5)
                    {
                        if (master_lock == 0)
                        {
                            int matrix_calculation = 30 - queue_count;
                            for (int i = 0; i <= 5; i++)
                            {
                                numbers.Enqueue(i);
                            }
                        }
                    }
                }
                numbers.Enqueue(1);
                eye_switch = 1;
            }
            else
            {
                if (queue_count >= 1)
                {
                    numbers.Dequeue();
                }
            }
            if (eye_switch == 1)
            {
                Resest_blink();
            }
            //Debug.Log("time in second = " + ((numbers.Count).ToString()));

            if (master_lock == 1)
            {
                if (numbers.Count > 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        numbers.Enqueue(i);
                    }
                    master_lock = 0;
                }
            }
          
        }
        void Resest_blink()
        {
            if ((PortS.brain_level_eye_blink) < 2110)
            {
                eye_blink.matrix.text = "NO";
                eye_switch = 0;
            }
        }

    }

}
