using QCMApp.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QCMApp.Models;

namespace QCMApp.Controllers
{// les éléments sont les descriptions !!!!!!
    public class DescriptionController : Controller
    {
        QuestionnaireManager qm = new QuestionnaireManager();
        ElementManager dm = new ElementManager();
        // GET: Element
        public ActionResult PageCreateDescription(int id)
        {
            Questionnaires questionnaire = new Questionnaires();
            questionnaire = qm.FindById(id);
            return View(questionnaire);
        }
        public ActionResult CreateDescription(string intitule, string texte,int idQuestionnaire)
        {
            Elements element = new Elements();
            Questionnaires questionnaire = new Questionnaires();
            element.intitule = intitule;
            element.texte = texte;
            element.questionnaire_id = idQuestionnaire;
            element.TypeElement_Id = 1;
            dm.InsertElement(element);         




            return RedirectToAction("PageCreateQuestionnaire", "Questionnaire",new { id = idQuestionnaire });
        }
        public ActionResult DeleteElement(int id)
        {
            Elements element = dm.FindById(id);
            var idQuestionnaire = element.questionnaire_id;
            dm.DeleteElement(element.Id);

            return RedirectToAction("PageCreateQuestionnaire", "Questionnaire", new { id = idQuestionnaire });
        }

        public ActionResult PageUpdateDescription(int id)
        {
            Elements element = dm.FindById(id);
            return View(element);
        }

        public ActionResult UpdateDescription(int idElement,int idQuestionnaire, string intitule, string texte)
        {
            var element = dm.FindById(idElement);
            element.intitule = intitule;
            element.texte = texte;
            dm.UpdateElement(element);
            return RedirectToAction("PageCreateQuestionnaire","Questionnaire",new { id = idQuestionnaire });
            
        }
    }
}