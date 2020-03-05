using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using System.IO;


namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]

    public class Control_dect : MonoBehaviour
    {
        private CarController m_Car20; // the car
        private int nextUpdate = 1;
        public int the_mode = 300;
        private int eye_switch = 0;
        private int the_queue_lock = 0;
        private int queue_count = 0;
        private int master_lock = 0;
        private AudioSource source;
        private int The_counter_m = 0;
        Queue numbers = new Queue();
        private int the_writer = 0;

        private int blink_to_write = 0;


        private void Awake()
        {
            // get the car type of EEG
            m_Car20 = GetComponent<CarController>();
            the_mode = MAIN1.Select_game_mode;
            if (MAIN1.Select_game_mode == 20)
            {
                for (int i = 0; i < (ENTER_Control_dect.the_ENTER_Control_dect); i++)
                {
                    numbers.Enqueue(i);
                }
            }
            source = GetComponent<AudioSource>();
        }

        private void FixedUpdate()
        {
            if (the_mode == 20)
            {

                if (The_counter_m < ENTER_Control_dect.the_ENTER_Control_dect)
                {
                   // CarController.the_speed = 50f;
                }
                The_counter_m = The_counter_m + 1;
                int queue_count = numbers.Count;
                if (queue_count > 0)
                {
                    // m_Car20.Move007(0, 1, 0, 0, 4);
                    EyeSCR.Eyescr_eye_open.text = "YES";
                 //   CarController.the_speed = 10f;
                    m_Car20.Move007(0, 1, 0, 0, 0);
                }
                if (queue_count <= 1)
                {
                    SceneManager.LoadScene(1);
                }
                if (Time.time >= nextUpdate)
                {
                    nextUpdate = Mathf.FloorToInt(Time.time) + 1;
                    queue_update();
                }
            }
        }

        void queue_update()
        {
            queue_count = numbers.Count;
            numbers.Dequeue();
            Remaining_time.Remaining_time_timer.text = ((numbers.Count).ToString());
            Debug.Log("SIZE = " + ((numbers.Count).ToString()));
            if ((PortS.brain_level_eye_blink) >= 109)
            {
               
                blink_to_write = 1;

            }
            else
            {
               
                blink_to_write = 0;
            }
            string root = @"C:\Users\bclaw\OneDrive\clawws\Documents\aoflogs\" + Input_name.the_user_name;

            // If directory does not exist, create it. 
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string path = Path.Combine(root, Input_name.the_user_name + "_control" + ".txt");


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
                    swAppend.WriteLine("MODE: Control");
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
                swAppend.WriteLine(DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "           " + (CarController.myspeed.ToString()) + "                 " + EyeSCR.Eyescr_eye_open.text + "                       " + (blink_to_write.ToString()));
                swAppend.Close();
            }
        }
    }

}
