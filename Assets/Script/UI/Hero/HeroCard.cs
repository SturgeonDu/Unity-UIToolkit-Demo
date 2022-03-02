using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class HeroCard : VisualElement
{
    public new class UxmlFactory : UxmlFactory<HeroCard, UxmlTraits>{};
    public new class UxmlTraits : VisualElement.UxmlTraits { }

    private VisualElement m_Root;

    private List<string> m_CharactorIconList = new List<string>() {"play_character_sample_1.png","play_character_sample_2.png","play_character_sample_3.png" };
    private List<string> m_BackgroundList = new List<string>() {"mission_reward_frame_green.png","mission_reward_frame_blue.png","mission_reward_frame_purple.png","mission_reward_frame_red.png" };
    private List<string> m_CountryFlagList = new List<string>()
    {
        "language_small_chn.png","language_small_deu.png","language_small_dng.png" ,"language_small_eng.png","language_small_esp.png","language_small_fra.png"
        ,"language_small_gre.png","language_small_idn.png","language_small_ina.png","language_small_ind.png","language_small_ita.png","language_small_jpn.png"
        ,"language_small_kor.png","language_small_pol.png","language_small_pra.png","language_small_prt.png","language_small_rou.png","language_small_rus.png"
        ,"language_small_swe.png","language_small_tha.png","language_small_tur.png","language_small_twn.png","language_small_ukr.png"
    };
    private readonly string m_RootPath = "Assets/Sprites/";
    
    public void Init(int idx,int rank,string name)
    {
        this.RegisterCallback<MouseDownEvent>((evt) =>
        {
            this.transform.scale = new Vector3(1.05f, 1.05f, 1.05f);
        });
        this.RegisterCallback<MouseUpEvent>((evt) =>
        {
            this.transform.scale = Vector3.one;
        });
        this.RegisterCallback<ClickEvent>((evt) =>
        {
            Debug.Log("Card " + idx + " clicked.");
            AddressableUtility.InstantiateAsync("HeroDetailUI",Vector3.zero, Quaternion.identity, null, (ins) =>
            {
                HeroDetailUI detail = ins.GetComponent<HeroDetailUI>();
                detail.Init(idx);
            });
        });
        
        m_Root = this.Q<VisualElement>("Root");
        m_Root.style.backgroundImage = _loadSprite(m_BackgroundList[(int)Random.Range(0f,m_BackgroundList.Count)]);
        
        var icon = this.Q<VisualElement>("Icon");
        icon.style.backgroundImage = _loadSprite(m_CharactorIconList[(int)Random.Range(0f,m_CharactorIconList.Count)]);

        var country = this.Q<VisualElement>("Country");
        country.style.backgroundImage = _loadSprite( "country/" + m_CountryFlagList[(int)Random.Range(0f,m_CountryFlagList.Count)]);

        var name_level = this.Q<Label>("NameAndLevel");
        name_level.text = idx + "  " + name;

        var rankNode = this.Q<VisualElement>("Rank");
        var rankList = rankNode.Children();
        _setRank(rank,rankList);
    }

    private void _setRank(int rank,IEnumerable<VisualElement> starList)
    {
        int i = 0;
        foreach (var ve in starList)
        {
            string spr = rank >= i ? "result_star.png" : "result_star_dim.png";
            ve.style.backgroundImage = _loadSprite(spr);
            i++;
        }
    }

    private StyleBackground _loadSprite(string name)
    {
        Sprite sprite = null;
#if UNITY_EDITOR
        string path = Path.Combine(m_RootPath, name);
        sprite = AssetDatabase.LoadAssetAtPath<Sprite>(path) as Sprite;
#endif
        var  sb = new StyleBackground(sprite);
        return sb;
    }
}
