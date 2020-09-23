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
            listeQuestionnaires = qm.SelectAll();
            return View(listeQuestionnaires);
        }
        public ActionResult PageCreateQuestionnaire()
        {
            return View();
        }
        public ActionResult CreateQuestionnaire(string intitule, int note)
        {
            var questionnaireEntity = new Questionnaires();
            questionnaireEntity.intitule = intitule;
            questionnaireEntity.note = note;
            questionnaireEntity.date = DateTime.Now;
            qm.InsertQuestionnaire(questionnaireEntity);
            return RedirectToAction("ListeQuestionnaires", "Questionnaire");
        }

        public ActionResult DeleteQuestionnaire(int id)
        {
            qm.DeleteQuestionnaire(id);
            return RedirectToAction("ListeQuestionnaires", "Questionnaire");
        }
        public ActionResult PageUpdateQuestionnaire(int id)
        {
            Questionnaires questionnaire = new Questionnaires();
            questionnaire = qm.FindById(id);
            return View(questionnaire);

        }
        public ActionResult UpdateQuestionnaire(string intitule, int note, int id)
        {
            Questionnaires questionnaire = new Questionnaires();
            questionnaire = qm.FindById(id);
            questionnaire.intitule = intitule;
            questionnaire.note = note;
            qm.UpdateQuestionnaire(questionnaire);
            return RedirectToAction("ListeQuestionnaires", "Questionnaire");
        }
        //TODO Voir pour l'update avec la configuration de la page création de questionnaire
    }
}