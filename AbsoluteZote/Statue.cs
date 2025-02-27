﻿namespace AbsoluteZote;
public class Statue : Module
{
    public Statue(AbsoluteZote absoluteZote) : base(absoluteZote)
    {
    }
    public override List<(string, string)> GetPreloadNames()
    {
        return new List<(string, string)>
        {
            ("GG_Workshop", "GG_Statue_Grimm"),
        };
    }
    public override void LoadPrefabs(Dictionary<string, Dictionary<string, GameObject>> preloadedObjects)
    {
        var ggStatueGrimm = preloadedObjects["GG_Workshop"]["GG_Statue_Grimm"];
        var dream = ggStatueGrimm.transform.Find("dream_version_switch").gameObject;
        dream.transform.Find("GG_statue_plinth_dream").gameObject.SetActive(false);
        dream.transform.Find("Statue Pt").gameObject.GetComponent<ParticleSystem>().startColor = new Color(.5f, .2f, .6f, 1);
        prefabs["dream"] = dream;
    }
    public override string UpdateText(string key, string sheet, string text)
    {
        if (key == "NAME_GREY_PRINCE" && sheet == "Journal")
        {
            if (Language.Language.CurrentLanguage() == Language.LanguageCode.ZH)
            {
                text = "无上左特";
            }
            else
            {
                text = "ABSOLUTE ZOTE";
            }
        }
        else if (key == "GG_S_MIGHTYZOTE" && sheet == "CP3")
        {
            if (Language.Language.CurrentLanguage() == Language.LanguageCode.ZH)
            {
                text = "混沌之神";
            }
            else
            {
                text = "God of chaos";
            }
        }
        return text;
    }
    public override void Initialize(UnityEngine.SceneManagement.Scene scene)
    {
        if (scene.name == "GG_Workshop")
        {
            var ggStatueGreyPrince = GameObject.Find("GG_Statue_GreyPrince");
            var dream = UnityEngine.Object.Instantiate(prefabs["dream"] as GameObject, ggStatueGreyPrince.transform);
            dream.name = "dream";
        }
    }
}
