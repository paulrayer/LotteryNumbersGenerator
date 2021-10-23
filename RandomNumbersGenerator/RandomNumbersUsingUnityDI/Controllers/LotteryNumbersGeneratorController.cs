using System;
using System.Web.Mvc;
using RandomNumbersUsingUnityDI.ViewModel;
using LotteryNumbersWriter;
using LotteryNumbersGenerator;

namespace RandomNumbersUsingUnityDI.Controllers
{
    public class LotteryNumbersGeneratorController : Controller
    {
        public ILotteryNumbersGenerator lotteryNumberGenerator;
        public ILotteryNumbersWriter lotteryNumbersWriter;
        
        public LotteryNumbersGeneratorController(
            ILotteryNumbersGenerator _lotteryNumberGenerator, 
            ILotteryNumbersWriter _lotteryNumbersWriter)
        {
            lotteryNumberGenerator = _lotteryNumberGenerator;
            lotteryNumbersWriter = _lotteryNumbersWriter;
        }

        // GET: LotteryNumbersGenerator
        public ActionResult Index()
        {
            return View(new NumberGeneratorViewModel() { Sets = 1 });
        }

        [HttpPost]
        public ActionResult GenerateNumbers(int sets, int? lotteryType)
        {
            //lotteryNumberGenerator.MinimumValue = 1;  
            //lotteryNumberGenerator.MaximumValue = 49;
            //lotteryNumberGenerator.NumbersPerSet = 6;
            var numbers = lotteryNumberGenerator.GenerateNumbers(sets, lotteryType.Value);

            var objNumberGenerator = new NumberGeneratorViewModel {
                Sets = sets,
                LotteryType = (LotteryNumberGeneratorEnums.LotteryTypes) Enum.Parse(typeof(LotteryNumberGeneratorEnums.LotteryTypes), lotteryType.Value.ToString()),
                RandomNumbers = numbers };

          //TODO  lotteryNumbersWriter.WriteToFile(numbers, @"C:\LotteryNumbersGenerator\in.txt");

            return PartialView("_GeneratedNumbers", objNumberGenerator);
        }

        [HttpPost]
        public JsonResult GenerateNumbersUsingAPI(int sets, int? lotteryType)
        {
            var numbers = lotteryNumberGenerator.GenerateNumbers(sets, lotteryType.Value);

            return Json(numbers, JsonRequestBehavior.AllowGet);
           
        }
    }
}