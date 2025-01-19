using System.Collections.Generic;
using UnityEngine;
using YG;

namespace YaAssets
{
    public static class Localization
    {
        private static Dictionary<string, string> _translations;

        public static void InitTranslations()
        {
            if (YandexGame.EnvironmentData.language == "en")
            {
                _translations = new()
                {
                    { "КОТ-КАТАСТРОФА", "КОТ-КАТАСТРОФА" },
                    { "СТАРТ", "СТАРТ" },
                    { "Играть снова", "Играть снова" },
                    { "Открыть уровень", "Открыть уровень" },
                    { "Сыграть ещё раз", "Сыграть ещё раз" },
                    { "Посмотреть рекламу и получить ", "Посмотреть рекламу и получить " },
                    { "с времени", "с времени" },
                    { "У ВАС ЕСТЬ ", "У ВАС ЕСТЬ " },
                    { "ЧТО БЫ ОТКРЫТЬ СЛЕДУЮЩИЙ УРОВЕНЬ ВАМ НУЖНО ","ЧТО БЫ ОТКРЫТЬ СЛЕДУЮЩИЙ УРОВЕНЬ ВАМ НУЖНО " },
                    { "ПОЗДРАВЛЯЕМ, ВЫ ПРОШЛИ ВСЕ УРОВНИ!!!","ПОЗДРАВЛЯЕМ, ВЫ ПРОШЛИ ВСЕ УРОВНИ!!!" }
                };
            }
            else if (YandexGame.EnvironmentData.language == "tr")
            {
                _translations = new()
                {
                    { "LevelКОТ-КАТАСТРОФА", "KEDİ FAKATI" },
                    { "СТАРТ", "BAŞLANGIÇ" },
                    { "Играть снова", "Tekrar oyna" },
                    { "Открыть уровень", "Açık seviye" },
                    { "Сыграть ещё раз", "Tekrar oyna" },
                    { "Посмотреть рекламу и получить ", "Reklamı izleyin ve alın " },
                    { "с времени", "s zaman" },
                    { "У ВАС ЕСТЬ ", "VAR " },
                    { "ЧТО БЫ ОТКРЫТЬ СЛЕДУЮЩИЙ УРОВЕНЬ ВАМ НУЖНО ","İHTİYACINIZ OLAN SONRAKİ SEVİYEYİ AÇMAK İÇİN " },
                    { "ПОЗДРАВЛЯЕМ, ВЫ ПРОШЛИ ВСЕ УРОВНИ!!!","TEBRİKLER, TÜM SEVİYELERİ GEÇTİNİZ!!!" }
                };
            }
            else
            {
                _translations = new()
                {
                    { "КОТ-КАТАСТРОФА", "CATASTROPHE CAT" },
                    { "СТАРТ", "START" },
                    { "Играть снова", "Play again" },
                    { "Открыть уровень", "Open level" },
                    { "Сыграть ещё раз", "Play one more time" },
                    { "Посмотреть рекламу и получить ", "Watch the ad and get " },
                    { "с времени" , "s of time" },
                    { "У ВАС ЕСТЬ " , "YOU HAVE " },
                    { "ЧТО БЫ ОТКРЫТЬ СЛЕДУЮЩИЙ УРОВЕНЬ ВАМ НУЖНО ","TO OPEN THE NEXT LEVEL YOU NEED " },
                    { "ПОЗДРАВЛЯЕМ, ВЫ ПРОШЛИ ВСЕ УРОВНИ!!!","CONGRATULATIONS, YOU HAVE PASSED ALL LEVELS!!!" }
                };
            }
        }

        public static string GetText(string key)
        {
            if (_translations.ContainsKey(key))
            {
                return _translations[key];
            }
            else
            {
                Debug.LogError($"Translation for {key} not found.");
                return key;
            }
        }
    }
}