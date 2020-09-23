using QCMApp.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QCMApp.Controllers
{
    public class ElementController : Controller
    {
        QuestionnaireManager qm = new QuestionnaireManager();
        ElementManager em = new ElementManager();
        // GET: Element
        public ActionResult PageCreateDescription(int id)
        {
            Questionnaires questionnaire = new Questionnaires();
            questionnaire = qm.FindById(id);
            return View(questionnaire);
        }
        public ActionResult CreateDescription(string intitule, string texte,int idQuestionnaire)
        {

            return RedirectToAction("CreateQuestionnaire", "Questionnaire");
        }
        public ActionResult PageCreateQuestion()
        {
            return View();
        }
    }
}