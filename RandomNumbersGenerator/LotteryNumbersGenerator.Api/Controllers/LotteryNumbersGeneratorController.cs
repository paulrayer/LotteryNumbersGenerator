using System.Collections.Generic;
using System.Web.Http;

namespace LotteryNumbersGenerator.Api.Controllers
{
    public class LotteryNumbersGeneratorController : ApiController
    {
        public ILotteryNumbersGenerator lotteryNumbersGenerator;

        public LotteryNumbersGeneratorController(ILotteryNumbersGenerator iLotteryNumbersGenerator)
        {
            lotteryNumbersGenerator = iLotteryNumbersGenerator;
        }

        [HttpGet]
        public List<int[]> Get(int id)
        {
            //return lotteryNumbersGenerator.GenerateNumbers(id, 1);
            return new List<int[]>();
        }
    }
}
