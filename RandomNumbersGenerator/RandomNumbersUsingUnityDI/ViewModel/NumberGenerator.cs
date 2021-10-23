using LotteryNumbersGenerator;
using System.Collections.Generic;
using static LotteryNumbersGenerator.LotteryNumberGeneratorEnums;

namespace RandomNumbersUsingUnityDI.ViewModel
{
    public class NumberGeneratorViewModel
    {
        public int Sets { get; set; }
        public IEnumerable<GeneratedNumbersDto> RandomNumbers { get; set; }
        public LotteryTypes LotteryType { get; set; }

        public string AdditionalBallName
        {
            get
            {
                switch (LotteryType)
                {
                    case LotteryTypes.EuroMillion:
                        return "Lucky stars";
                    case LotteryTypes.LottolandCash4Life:
                        return "Cash Ball";
                    default:
                        return "Life Ball";
                }
            }
        }
    }
}