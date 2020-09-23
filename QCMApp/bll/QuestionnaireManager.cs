using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QCMApp.bll
{
    public class QuestionnaireManager
    {

        private List<Questionnaires> listeQuestionnaires = new List<Questionnaires>();


        public List<Questionnaires> SelectAll()
        {
            using (var context = new QCMAppBDDEntities())
            {
                listeQuestionnaires = context.Questionnaires.ToList();
            }

            return listeQuestionnaires;
        }
        public Questionnaires FindById(int id)
        {
            Questionnaires questionnaire = new Questionnaires();
            using (var context = new QCMAppBDDEntities())
            {
                try
                {
                    questionnaire = context.Questionnaires.Find(id);
                    
                }
                catch (SqlException e)
                {

                    throw;
                }

            }

            return questionnaire;
        }
        public Questionnaires FindByIntitule(String intitule)
        {
            Questionnaires questionnaire = new Questionnaires();
            using (var context = new QCMAppBDDEntities())
            {
                try
                {
                    questionnaire = context.Questionnaires.Where(q => q.intitule == intitule).Select(q=>q).FirstOrDefault();

                }
                catch (SqlException e)
                {

                    throw;
                }

            }

            return questionnaire;
        }
        public void InsertQuestionnaire(Questionnaires questionnaire)
        {
            using (var context = new QCMAppBDDEntities())
            {
                try
                {
                    context.Questionnaires.Add(questionnaire);
                    context.SaveChanges();
                }
                catch (SqlException e)
                {

                    throw;
                }

            }

        }
        public void DeleteQuestionnaire(int id)
        {
            Tools.Logger.Ecrire(Tools.Logger.Niveau.Info, string.Format("Debut DeleteQuestionnaire({0})", id));
            using (var context = new QCMAppBDDEntities())
            {
                Questionnaires questionnaire = context.Questionnaires.Find(id);
                try
                {
                    context.Questionnaires.Remove(questionnaire);
                    context.SaveChanges();
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }
        public void UpdateQuestionnaire(Questionnaires questionnaire)
        {
            using (var context = new QCMAppBDDEntities())
            {

                try
                {
                    context.Questionnaires.AddOrUpdate(questionnaire);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}