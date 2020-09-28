using QCMApp.bll;
using QCMApp.Models;
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
        ElementManager em = new ElementManager();
        // GET: Questionnaire
        public ActionResult ListeQuestionnaires()
        {
            List<Questionnaires> listeQuestionnaires = new List<Questionnaires>();
            listeQuestionnaires = qm.SelectAll();
            //listeQuestionnaires.OrderBy()
            return View(listeQuestionnaires);
        }
        //public ActionResult PageCreateQuestionnaire(ViewModelQuestionnaireElements vm)
        [HttpGet]
        public ActionResult PageCreateQuestionnaire(int id)
        {
            // Je dois créer le viewModel dans l'ActionResult qui amène à la View
            var questionnaireEntity = new Questionnaires();
            ViewModelQuestionnaireElements vmqe = new ViewModelQuestionnaireElements();

            //questionnaireEntity = qm.FindById(vm.idQuestionnaire);
            questionnaireEntity = qm.FindById(id);
            vmqe.questionnaire = questionnaireEntity;
            //vmqe.elements = em.SelectAllFromQuestionnaire(vm.idQuestionnaire);
            vmqe.elements = em.SelectAllFromQuestionnaire(id);
            return View(vmqe);
        }
        public ActionResult PageCreateIntituleQuestionnaire()
        {
            return View();
        }

        public ActionResult CreateIntituleQuestionnaire(string intitule)
        {
            // la création de l'intitulé du questionnaire va créer le questionnaire et amner sur la page de création du questionnaire
            ViewModelQuestionnaireElements vm = new ViewModelQuestionnaireElements();
            var questionnaireEntity = new Questionnaires();
            questionnaireEntity.intitule = intitule;
            questionnaireEntity.date = DateTime.Now;
            qm.InsertQuestionnaire(questionnaireEntity);
            //int id = questionnaireEntity.Id;
            //vm.idQuestionnaire = questionnaireEntity.Id;
            int id = questionnaireEntity.Id;



            //return RedirectToAction("PageCreateQuestionnaire", "Questionnaire", vm) ;
            return RedirectToAction("PageCreateQuestionnaire", "Questionnaire", new { id = id });
        }

        public ActionResult CreateQuestionnaire(string intitule, int note, int id)
        {
            var questionnaireEntity = new Questionnaires();
            questionnaireEntity.intitule = intitule;
            questionnaireEntity.note = note;
            questionnaireEntity.date = DateTime.Now;
            questionnaireEntity.Id = id;
            qm.UpdateQuestionnaire(questionnaireEntity);
            return RedirectToAction("ListeQuestionnaires", "Questionnaire");
        }

        public ActionResult DeleteQuestionnaire(int id)
        {
            qm.DeleteQuestionnaire(id);
            return RedirectToAction("ListeQuestionnaires", "Questionnaire");
        }
        public ActionResult PageUpdateQuestionnaire(int id)
        {
            ViewModelQuestionnaireElements vmqe = new ViewModelQuestionnaireElements();
            Questionnaires questionnaire = new Questionnaires();
            //questionnaire = qm.FindById(id);
            //vmqe.questionnaire = qm.FindById(id);
            //vmqe.elements = em.SelectAllFromQuestionnaire(id);
            //return View(questionnaire);
            return RedirectToAction("PageCreateQuestionnaire", "Questionnaire", new { id = id });
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