namespace Assets.GameScripts.Models
{
    public static class GameVars
    {
        public static float CameraMoveSpeed = 3.5f;
        public static Difficulty Difficulty = Difficulty.Easy;
    }

    public enum Difficulty
    {
        Easy,
        Hard
    }
}
