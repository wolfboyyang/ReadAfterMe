using UnityEngine;
using System.Collections;

namespace ReadAfterMe
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        AudioSource audioSource;
        string mic = "Built-in Microphone";
        //The maximum amount of sample data that gets loaded in, best is to leave it on 256, unless you know what you are doing. 
        //A higher number gives more accuracy but lowers performance alot, it is best to leave it at 256.
        public int amountSamples = 256;



        public float averagedVolume;

        private float[] audioSamples;

        private float silentTime;
        private float recordingTime;

        private bool startPlayback;


        // Use this for initialization
        void Start()
        {
            audioSamples = new float[amountSamples];

            audioSource = GetComponent<AudioSource>();

            //waveCurve = new VectorLine("WaveCurve", new List<Vector2>(), 1, LineType.Continuous);
            //for (int i = 0; i < amountSamples; i++)
            //    waveCurve.points2.Add(new Vector2(startX+i*scaleX*length/amountSamples, startY));
            //waveCurve.Draw();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Microphone.IsRecording(mic))
            {
                recordingTime += Time.fixedDeltaTime;
                UpdateAveragedVolume();
                if (averagedVolume < 0.01)
                {
                    silentTime += Time.fixedDeltaTime;
                    if (silentTime > 0.2)
                    {
                        Microphone.End(mic);
                        if (recordingTime > 1)
                        {
                            audioSource.Play();
                            startPlayback = true;
                        }
                        else
                        {
                            StartRecording();
                        }
                    }
                }
                else
                    silentTime = 0;
            }

            if (startPlayback)
            {
                recordingTime -= Time.fixedDeltaTime;
                if (recordingTime < 0)
                {
                    audioSource.Stop();
                    startPlayback = false;
                    StartRecording();
                }
            }
 
            //DrawWaveCurve(); 
        }

        public void Record()
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            startPlayback = false;

            if (!Microphone.IsRecording(mic))
            {
                StartRecording();
            }
            else
            {
                Microphone.End(mic);
            }

        }

        private void StartRecording()
        {
            audioSource.clip = Microphone.Start(mic, true, 10, 44100);
            silentTime = 0;
            recordingTime = 0;
        }

        private void UpdateAveragedVolume()
        {
            float a = 0;
            int position = 0;
            int micPosition = 0;
            if(Microphone.IsRecording(mic))
                micPosition = Microphone.GetPosition(mic);
            else
                micPosition = audioSource.timeSamples;
            if (micPosition > amountSamples)
                position = micPosition - amountSamples;
            audioSource.clip.GetData(audioSamples, position);
            for(int i=0;i<amountSamples;i++)
            {
                a += Mathf.Abs(audioSamples[i]);
            }
            averagedVolume = a / amountSamples;
        }

    }
}