
using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]

    public class Sleep_controller : MonoBehaviour
    {
        private CarController m_Car01; // the car
        private int nextUpdate = 1;
        public int the_mode = 300;
        private int eye_switch = 0;
        private int the_queue_lock = 0;
        private int queue_count = 0;
        private int master_lock = 0;
        private int lock1 = 0;
        private int lock2 = 0;
        private int lock3 = 0;
        // private AudioSource source;
        private int The_counter_m = 0;
        private int Bsound1 = 0;
        private float Bsound2 = 0;
        private float Bsound3 = 0;
        private float Bsound4 = 0;
        Queue numbers = new Queue();
        Queue starter = new Queue();
        private int thetime = 0;
        private int the_queue_size_1 = 3;
        private int the_queue_size_2 = 6;
        private int the_block_1 = 0;
        private int the_block_2 = 0;
        private int the_block_3 = 0;
        private int the_speed_1 = 0;
        private int the_speed_2 = 0;
        private int the_speed_3 = 0;

        private int dead_locker1 = 0;
        private int dead_locker2 = 0;
        private int dead_locker3 = 0;

        private int the_writer = 0;

        private int blink_to_write = 0;

        private float nextActionTime = 0.0f;
        public float period = 0.1f;




        public AudioSource driverawakeness;
        public AudioSource driverdrowsiness;
        public AudioSource driversleepstate;
        public AudioSource drivefullasleep;

        public void the_sound1()
        {

            drivefullasleep.Play();
        }
        public void the_sound2()
        {

            driverdrowsiness.Play();
        }
        public void the_sound3()
        {

            driversleepstate.Play();
        }
        

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

        }

        private void FixedUpdate()
        {
            //
            //   FREQ_scr.FREQ_scr_open.text = (CarController.my_speed).ToString();
            if (the_mode == 1)
            {
                int queue_starter = starter.Count;
                if ((queue_starter > 2) && (dead_locker1 == 1))
                {
                    dead_locker1 = 0;

                   
                    for (int i = 0; i < queue_starter; i++)
                    {
                        starter.Dequeue();
                    }
                    for (int i = 0; i < 30; i++)
                    {
                        numbers.Enqueue(1);
                    }
                    lock1 = 0;
                    lock2 = 0;
                    lock3 = 0;
                }
                if (dead_locker1 == 0)
                {
                    int queue_count = numbers.Count;

                    if (lock1 == 0)
                    {
                        EyeSCR.Eyescr_eye_open.text = "YES";
                        m_Car01.Move007(0, 1, 0, 0, 0);

                    }

                    if (the_speed_1 == 1)
                    {
                        EyeSCR.Eyescr_eye_open.text = "YES";
                        m_Car01.Move007(0, 1, 0, 0, 1);
                    }

                    if (the_speed_2 == 1)
                    {
                        EyeSCR.Eyescr_eye_open.text = "YES";
                        m_Car01.Move007(0, 1, 0, 0, 2);
                    }

                    if (queue_count == 20)
                    {
                     //   CarAudio.StopSound();
                        the_sound2();
                        Bsound1 = 1;
                        lock1 = 1;
                        the_speed_1 = 1;
                    }

                    if (queue_count == 10)
                    {
                     //   CarAudio.StopSound();
                        the_sound3();
                        Bsound2 = 1;
                        lock1 = 1;
                        the_speed_2 = 1;

                    }

                    if (queue_count == 1)
                    {
                        the_sound1();
                        m_Car01.Move007(0, 0, 0, 0, 0);
                        EyeSCR.Eyescr_eye_open.text = "NO";
                        lock1 = 1;
                        dead_locker1 = 1;

                    }
                    FREQ_scr.FREQ_scr_open.text = CarController.myspeed.ToString();



                    if (Time.time >= nextUpdate)
                    {
                        nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                        queue_update();


                        if (30 <= 30)
                        {
                            if (thetime >= 30)
                            {
                                thetime = 0;
                            }
                        }
                    }

                }
                if (dead_locker1 == 1)
                {
                    if (Time.time >= nextUpdate)
                    {
                        nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                        queue_update();
                    }

                }

            }
        }

        void queue_update()
        {


            queue_count = numbers.Count;
            Debug.Log("time in second = " + (thetime.ToString()));
            if ((PortS.brain_level_eye_blink) >= 109)
            {
                if (dead_locker1 == 0)
                {
                    int new_numb = ((30) - (numbers.Count)) + 15;
                    for (int i = 0; i < new_numb; i++)
                    {
                        numbers.Enqueue(1);
                    }
                }
                if (dead_locker1 == 1)
                {

                    starter.Enqueue(1);
                    Debug.Log(" queue_starter " + ((starter.Count).ToString()));

                }
                blink_to_write = 1;

            }
            else
            {
                if (dead_locker1 == 0)
                {
                    if (numbers.Count > 0)
                    {
                        numbers.Dequeue();
                        Debug.Log(" queue_count " + ((queue_count).ToString()));
                    }
                }
                blink_to_write = 0;
            }
            string root = @"C:\Users\bclaw\OneDrive\clawws\Documents\aoflogs\" + Input_name.the_user_name;
 
            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string path = Path.Combine(root, Input_name.the_user_name + "_experiment" + ".txt");


            string getter_blink = blink_to_write.ToString();
                
            if (!File.Exists(path))
            {
                // Create a file to write to.
                
                if (the_writer == 0)
                {
                    StreamWriter swNew = File.CreateText(path);
                    swNew.WriteLine("S NAME:" + Input_name.the_user_name);
                    swNew.Close();

                    StreamWriter swAppend = File.AppendText(path);
                    swAppend.WriteLine("DATE:" + (System.DateTime.Now.ToShortDateString()));
                    swAppend.WriteLine("TIME:" + (DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)));
                    swAppend.WriteLine("MODE: Experiment");
                    swAppend.WriteLine("");
                    swAppend.WriteLine("");
                    swAppend.WriteLine("TIME             SPEED             EYE OPEN/CLOSE             BLINK");
                    swAppend.Close();
                    the_writer = 1;
                }
              
            }
            else
            {

                StreamWriter swAppend = File.AppendText(path);
                swAppend .WriteLine(DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "           " + (CarController.myspeed.ToString()) + "                 " + EyeSCR.Eyescr_eye_open.text + "                       " + (blink_to_write.ToString()));
                swAppend .Close();
            }
            thetime = thetime + 1;
        }

    }
}
