using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace EasyGameStudio.fat_thin_built_in
{
    public class Demo_control : MonoBehaviour
    {
        public GameObject[] game_objects_kyle;


        public AudioSource audio_source;
        public AudioClip ka;
        public Text text_title;
        public string[] string_titles;

        private int index_kyle = 0;



        void Start()
        {
           
        }

        public void on_next_btn()
        {
            this.index_kyle++;
            if (this.index_kyle >= this.game_objects_kyle.Length)
                this.index_kyle = 0;


            for (int i = 0; i < this.game_objects_kyle.Length; i++)
            {
                if (i == this.index_kyle)
                {
                    this.game_objects_kyle[i].SetActive(true);
                }
                else
                {
                    this.game_objects_kyle[i].SetActive(false);
                }
            }

            this.text_title.text = this.string_titles[this.index_kyle];

            this.audio_source.PlayOneShot(this.ka);
        }

        public void on_previous_btn()
        {
            this.index_kyle--;
            if (this.index_kyle < 0)
                this.index_kyle = this.game_objects_kyle.Length-1;


            for (int i = 0; i < this.game_objects_kyle.Length; i++)
            {
                if (i == this.index_kyle)
                {
                    this.game_objects_kyle[i].SetActive(true);
                }
                else
                {
                    this.game_objects_kyle[i].SetActive(false);
                }
            }

            this.text_title.text = this.string_titles[this.index_kyle];

            this.audio_source.PlayOneShot(this.ka);
        }


       
    }
}