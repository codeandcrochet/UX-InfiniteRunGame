using UnityEngine;

namespace Assets.GameScripts.Models
{
    public static class GameVars
    {
        public static float InitialCameraMoveSpeed = 3.5f;
        public static float CameraMoveSpeed = 3.5f;
        public static float speedIncreaseRate = 0.1f; 
        public static Difficulty Difficulty = Difficulty.Easy;

        public static void IncreaseSpeed()
        {
            CameraMoveSpeed += speedIncreaseRate * Time.deltaTime;
            Debug.Log($"speed up!: {CameraMoveSpeed}");
        }
        public static void ResetSpeed()
        {
            CameraMoveSpeed = InitialCameraMoveSpeed; // Reset speed to initial value
        }
    }

   

    public enum Difficulty
    {
        Easy,
        Hard
    }
}