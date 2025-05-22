public class VMGameState
{
    public enum EGameState { Play, OpenUI }

    private static EGameState curState = EGameState.Play;


    public static void Play() { curState = EGameState.Play; }
    public static void OpenUI() { curState = EGameState.OpenUI; }

    public static bool IsPlay() { return curState == EGameState.Play; }
    public static bool IsOpenUI() { return curState == EGameState.OpenUI; }
}