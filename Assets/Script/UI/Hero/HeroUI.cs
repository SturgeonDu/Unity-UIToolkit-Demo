using UnityEngine;
using UnityEngine.UIElements;

public class HeroUI : MonoBehaviour
{
    [SerializeField]
    private VisualTreeAsset m_HeroCardHorizontalLineAsset;
    [SerializeField]
    private VisualTreeAsset m_HeroCardAsset;
    
    private VisualElement m_Root;
    private ScrollView m_ScrollView;
    
    
    // Start is called before the first frame update
    void Start()
    {
        var doc = GetComponent<UIDocument>();
        m_Root = doc.rootVisualElement;

        var btn_Filter = m_Root.Q<Button>("Button-Filter");
        btn_Filter.clicked += onBtn_Filter;

        var btn_Pokedex = m_Root.Q<Button>("Button-Pokedex");
        btn_Pokedex.clicked += onBtn_Pokedex;
        
        var btn_Return = m_Root.Q<Button>("Button-Return");
        btn_Return.clicked += onBtn_Return;

        m_ScrollView = m_Root.Q<ScrollView>("HeroScrollView");
        _initHeroCard(53,5);
    }

    void _initHeroCard(int iTotalHeroCount,int iLineCount)
    {
        int iLine = iTotalHeroCount % iLineCount != 0 ? iTotalHeroCount / iLineCount + 1 : iTotalHeroCount / iLineCount;
        for (int i = 1;i <= iLine;i++)
        {
            // var asset = m_HeroCardAsset.CloneTree();
            // var card = asset.Q<HeroCard>();
            // card.Init(i,i,"Hero Name " + i);
            // m_ScrollView.Add(card);
            
            var asset = m_HeroCardHorizontalLineAsset.CloneTree();
            var horizontalLine = asset.Q<HeroCardHorizontalLine>();
            int heroCount = i * iLineCount <= iTotalHeroCount ? iLineCount : iTotalHeroCount % iLineCount;
            horizontalLine.Init(i,heroCount,m_HeroCardAsset);
            m_ScrollView.Add(horizontalLine);
        }
    }

    void onBtn_Filter()
    {
        Debug.Log("onBtn_Filter");
    }
    
    void onBtn_Pokedex()
    {
        Debug.Log("onBtn_Pokedex");
    }
    
    void onBtn_Return()
    {
        Debug.Log("onBtn_Return");
    }
}
