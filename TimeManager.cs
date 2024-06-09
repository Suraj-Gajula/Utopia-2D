using UnityEngine;
public struct TimeSet{
    public int minutes;
    public int seconds;
    public TimeSet(int minutes, int seconds){
        this.minutes = minutes;
        this.seconds = seconds;
    }
    public override string ToString(){
        return string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
}
public static class TimeManager{
    private static TimeSet[] timeSets = new TimeSet[10];
    public static int CurrentLevel;
    static TimeManager(){
        for (int i = 0; i < timeSets.Length; i++){
            timeSets[i] = new TimeSet(0, 0);
        }
    }
    public static TimeSet GetTimeSet(int index){
        return timeSets[index];
    }
    public static void SetTimeSet(int minutes, int seconds){
        timeSets[CurrentLevel - 1] = new TimeSet(minutes, seconds);
    }
    public static void SetLevel(int Level){
        CurrentLevel = Level;
    }
    public static void ResetAllTimeSets(){
        for (int i = 0; i < timeSets.Length; i++){
            timeSets[i] = new TimeSet(0, 0);
        }
    }
}