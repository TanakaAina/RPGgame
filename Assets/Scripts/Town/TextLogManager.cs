using UnityEngine;
using UnityEngine.UI;
 
public class TextLogManager : MonoBehaviour
{
 //ダンジョンログ
 public static Text combat_log_text;
 public static string dungeon_log;
 
       void Start()
       {
              //combat_log_textという名前のオブジェクトを探してテキストコーポネントを格納
              combat_log_text = GameObject.Find("combat_log_text").GetComponent<Text>();
              TextLogManager.dungeon_log += "\n街についた。\n街の人に話を聞こう。\n";
              TextLogManager.update_dungeon_log();
       }
 
       public static void update_dungeon_log()
       {
              combat_log_text.text = dungeon_log;
       }
 
}