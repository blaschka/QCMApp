using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QCMApp.bll
{
    public class QuestionnaireManager
    {

        private List<Questionnaires> listeQuestionnaires = new List<Questionnaires>();


        public List<Questionnaires> selectAll()
        {
            using(var context = new QCMAppBDDEntities3())
            {
                listeQuestionnaires = context.Questionnaires.ToList();
            }

            return listeQuestionnaires;
        }
        public void insertQuestionnaire(Questionnaires questionnaire)
        {
            using (var context = new QCMAppBDDEntities3())
            {
                try
                {
                    context.Questionnaires.Add(questionnaire);
                }
                catch (SqlException e)
                {

                    throw;
                }

            }

        }
    }
}