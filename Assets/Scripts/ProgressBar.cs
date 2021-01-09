using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private static Slider progressSlider;






    /// </summary>
    private void Start()
    {
        progressSlider = GetComponent<Slider>();
    }
}