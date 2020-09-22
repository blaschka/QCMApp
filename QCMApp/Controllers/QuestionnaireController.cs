using QCMApp.bll;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QCMApp.Controllers
{
    public class QuestionnaireController : Controller
    {
        QuestionnaireManager qm = new QuestionnaireManager();
        // GET: Questionnaire
        public ActionResult ListeQuestionnaires()
        {
            List<Questionnaires> listeQuestionnaires = new List<Questionnaires>();
            listeQuestionnaires = qm.selectAll();
            return View(listeQuestionnaires);
        }
        public ActionResult CreateQuestionnaire()
        {
            return View();
        }
        public ActionResult InsertQuestionnaire(string intitule, int note)
        {
            var questionnaireEntity = new Questionnaires();
            questionnaireEntity.intitule = intitule;
            questionnaireEntity.note = note;
            qm.insertQuestionnaire(questionnaireEntity);
            return RedirectToAction("ListeQuestionnaires", "Questionnaire");
        }
        public ActionResult UpdateQuestionnaire(Questionnaires questionnaire)
        {
            return RedirectToAction("ListeQuestionnaires", "Questionnaire");
        }
    }
}