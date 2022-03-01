using System.Collections.Generic;
using UnityEngine.UIElements;

public class HeroCardHorizontalLine : VisualElement
{
    public new class UxmlFactory : UxmlFactory<HeroCardHorizontalLine, UxmlTraits>{};
    public new class UxmlTraits : VisualElement.UxmlTraits { }

    public void Init(int line,int count,VisualTreeAsset cardAsset)
    {
        for (int i = 0; i < count; i++)
        {
            var card = cardAsset.CloneTree();
            var cardEntry = card.Q<HeroCard>();

            int totalIndex = (line - 1) * 5 + i + 1;
            int rank = totalIndex % 5;
            string name = "Hero Name " + totalIndex;
            
            cardEntry.Init(totalIndex,rank,name);
            this.Add(cardEntry);
        }

    }
}