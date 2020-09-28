using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QCMApp.bll;

namespace QCMApp.Controllers
{
    public class QuestionController : Controller
    {
        QuestionnaireManager qm = new QuestionnaireManager();
        ElementManager em = new ElementManager();
        // GET: Element
        public ActionResult PageCreateQuestion(int id)
        {
            Questionnaires questionnaire = new Questionnaires();
            questionnaire = qm.FindById(id);
            return View(questionnaire);
        }
        public ActionResult CreateQuestion(string intitule, string texte, int idQuestionnaire)
        {
            Elements element = new Elements();
            Questionnaires questionnaire = new Questionnaires();
            int count = em.SelectAllFromQuestionnaire(idQuestionnaire).Count;

            element.intitule = intitule;
            element.texte = texte;
            element.questionnaire_id = idQuestionnaire;
            element.TypeElement_Id = 2;
            element.ordre = count + 1;
            em.InsertElement(element);




            return RedirectToAction("PageCreateQuestionnaire", "Questionnaire", new { id = idQuestionnaire });
        }
        public ActionResult DeleteQuestion(int id)
        {
            Elements element = em.FindById(id);
            var idQuestionnaire = element.questionnaire_id;
            em.DeleteElement(element.Id);

            return RedirectToAction("PageCreateQuestionnaire", "Questionnaire", new { id = idQuestionnaire });
        }

        public ActionResult PageUpdateQuestion(int id)
        {
            Elements element = em.FindById(id);
            return View(element);
        }

        public ActionResult UpdateQuestion(int idElement, int idQuestionnaire, string intitule, string texte)
        {
            var element = em.FindById(idElement);
            element.intitule = intitule;
            element.texte = texte;
            em.UpdateElement(element);
            return RedirectToAction("PageCreateQuestionnaire", "Questionnaire", new { id = idQuestionnaire });

        }
    }
}