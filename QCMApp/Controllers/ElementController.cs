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
        public ActionResult ElementUp(int idElement)
        {
            Elements element = em.FindById(idElement);
            em.elementUp(idElement);

            return RedirectToAction("PageCreateQuestionnaire", "Questionnaire", new { id = element.questionnaire_id });
        }
        public ActionResult ElementDown(int idElement)
        {
            Elements element = em.FindById(idElement);
            em.elementDown(idElement);

            return RedirectToAction("PageCreateQuestionnaire", "Questionnaire", new { id = element.questionnaire_id });
        }
    }
}