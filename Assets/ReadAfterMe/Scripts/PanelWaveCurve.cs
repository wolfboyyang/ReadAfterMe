using UnityEngine;
using System.Collections;

namespace ReadAfterMe
{
    /// <summary>
    /// This script create an audio waveform on top of a UI panel.
    /// </summary>
	[RequireComponent(typeof(RectTransform))]
    public class PanelWaveCurve : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void DrawWaveCurve()
        {
            /*float[] audioSamples;
            if (frequencyRange == FrequencyRange.Decibal)
            {
                audioSamples = AudioSampler.instance.GetAudioSamples(audioSource, numColumns, true);
            }
            else
            {
                audioSamples = AudioSampler.instance.GetFrequencyData(audioSource, frequencyRange, numColumns, true);
            }

            int index = 0;
            //render the correct objects

            for (int r = 0; r < numRows; r++) // for each row
            {
                for (int c = 0; c < numColumns; c++)
                {
                    float sampleHeight = Mathf.Abs(audioSamples[c]) * sensitivity; //get an audio sample for each column

                    float currentHeight = (float)r / numRows; // the % this row is out of numrows, i.e. how high we are
                    GameObject cell = cells[index];

                    if (currentHeight <= sampleHeight) // if this height is < our sample height, enable the cell
                    {
                        cell.SetActive(true);
                    }
                    else // otherwise we should turn this cell off
                    {
                        cell.SetActive(false);
                    }
                    index++;
                }
            }*/
        }
    }
}