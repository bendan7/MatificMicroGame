

using System.Collections.Generic;

public static class ItemsDataGetter
{

    public static Dictionary<string, ItemData> GetItemsData()
    {
        return new Dictionary<string, ItemData>()
        {
            {"eyes_1",new ItemData(){ Section = CustomizationType.Eyes , Price =400 , MinLevel =8} },
            {"eyes_2",new ItemData(){ Section = CustomizationType.Eyes , Price =0, MinLevel =6} },
            {"eyes_3",new ItemData(){ Section = CustomizationType.Eyes , Price =700 , MinLevel =0} },
            {"eyes_4",new ItemData(){ Section = CustomizationType.Eyes , Price =0 , MinLevel =0} },
            {"eyes_5",new ItemData(){ Section = CustomizationType.Eyes , Price =0 , MinLevel =0} },
            {"eyes_6",new ItemData(){ Section = CustomizationType.Eyes , Price =0 , MinLevel =5} },
            {"eyes_7",new ItemData(){ Section = CustomizationType.Eyes , Price =0 , MinLevel =4} },
            {"eyes_8",new ItemData(){ Section = CustomizationType.Eyes , Price =0 , MinLevel =2} },
            {"eyes_9",new ItemData(){ Section = CustomizationType.Eyes , Price =620 , MinLevel =0} },
            {"eyes_10",new ItemData(){ Section = CustomizationType.Eyes , Price =70 , MinLevel =0} },

            {"mouth_1",new ItemData(){ Section = CustomizationType.Mouths , Price =0 , MinLevel =0} },
            {"mouth_2",new ItemData(){ Section = CustomizationType.Mouths , Price =0 , MinLevel =0} },
            {"mouth_3",new ItemData(){ Section = CustomizationType.Mouths , Price =0 , MinLevel =7} },
            {"mouth_4",new ItemData(){ Section = CustomizationType.Mouths , Price =0 , MinLevel =3} },
            {"mouth_5",new ItemData(){ Section = CustomizationType.Mouths , Price =0 , MinLevel =4} },
            {"mouth_6",new ItemData(){ Section = CustomizationType.Mouths , Price =700 , MinLevel =0} },
            {"mouth_7",new ItemData(){ Section = CustomizationType.Mouths , Price =260 , MinLevel =0} },
            {"mouth_8",new ItemData(){ Section = CustomizationType.Mouths , Price =1 , MinLevel =0} },
            {"mouth_9",new ItemData(){ Section = CustomizationType.Mouths , Price =0 , MinLevel =5} },
            {"mouth_10",new ItemData(){ Section = CustomizationType.Mouths , Price =0 , MinLevel =0} },
            {"mouth_11",new ItemData(){ Section = CustomizationType.Mouths , Price =555 , MinLevel =0} },

            {"outfit_01",new ItemData(){ Section = CustomizationType.Outfits , Price =0 , MinLevel =5} },
            {"outfit_02",new ItemData(){ Section = CustomizationType.Outfits , Price =0 , MinLevel =5} },
            {"outfit_03",new ItemData(){ Section = CustomizationType.Outfits , Price =0 , MinLevel =6} },
            {"outfit_04",new ItemData(){ Section = CustomizationType.Outfits , Price =0 , MinLevel =3} },
            {"outfit_05",new ItemData(){ Section = CustomizationType.Outfits , Price =360 , MinLevel =0} },
            {"outfit_06",new ItemData(){ Section = CustomizationType.Outfits , Price =0 , MinLevel =0} },
            {"outfit_07",new ItemData(){ Section = CustomizationType.Outfits , Price =100 , MinLevel =0} },
            {"outfit_08",new ItemData(){ Section = CustomizationType.Outfits , Price =0 , MinLevel =0} },
            {"outfit_09",new ItemData(){ Section = CustomizationType.Outfits , Price =0 , MinLevel =0} },
            {"outfit_10",new ItemData(){ Section = CustomizationType.Outfits , Price =1000 , MinLevel =0} },


        };
    }


}
