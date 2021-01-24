using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTileMaker : EditorWindow
{
    public static RandomTileMaker ew;
    public RuleTile irt;
   // public WeightedRandomTile wrt;

    public Texture2D t;


    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/RandomTileMakerEditor")]
    public static void ShowWindow()
    {
        ew = (RandomTileMaker)EditorWindow.GetWindow(typeof(RandomTileMaker));
    }

    void OnGUI()
    {
        GUILayout.Label("Tile Settings. Choose One:", EditorStyles.boldLabel);

        irt = EditorGUILayout.ObjectField("Rule Tile", irt, typeof(RuleTile), true) as RuleTile;
     //   wrt = EditorGUILayout.ObjectField("Weighted Random Tile", wrt, typeof(WeightedRandomTile), true) as WeightedRandomTile;
        t = EditorGUILayout.ObjectField("Texture", t, typeof(Texture2D), true) as Texture2D;
        if (t == null)
        {
            return;
        }
        if (irt != null)
        {
            if (GUILayout.Button("Add new rule with sprites"))
            {
                string spriteSheet = AssetDatabase.GetAssetPath(t);
                Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheet)
                    .OfType<Sprite>().ToArray();
                RuleTile.TilingRule rt = new RuleTile.TilingRule();
                rt.m_Output = RuleTile.TilingRuleOutput.OutputSprite.Random;


                rt.m_Sprites = sprites.ToArray();
                irt.m_TilingRules.Add(rt);
            }
        }
       /* else if (wrt != null)
        {
            if (GUILayout.Button("Override !!! sprites"))
            {
                string spriteSheet = AssetDatabase.GetAssetPath(t);
                Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheet)
                    .OfType<Sprite>().ToArray();
                List<WeightedSprite> wss = new List<WeightedSprite>();

                for (int i = 0; i < sprites.Length; i++)
                {
                    wss.Add(new WeightedSprite()
                    {
                        Sprite = sprites[i],
                        Weight = 100
                    });
                }
                wrt.Sprites = wss.ToArray();
                wrt.flags = TileFlags.LockAll;
            }
            if (GUILayout.Button("Add sprites to existing"))
            {
                string spriteSheet = AssetDatabase.GetAssetPath(t);
                Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(spriteSheet)
                    .OfType<Sprite>().ToArray();
                List<WeightedSprite> wss = new List<WeightedSprite>();
                wss.AddRange(wrt.Sprites.ToList());

                for (int i = 0; i < sprites.Length; i++)
                {
                    wss.Add(new WeightedSprite()
                    {
                        Sprite = sprites[i],
                        Weight = 100
                    });
                }
                wrt.Sprites = wss.ToArray();

                wrt.flags = TileFlags.LockAll;

            }
        }*/
    }
}