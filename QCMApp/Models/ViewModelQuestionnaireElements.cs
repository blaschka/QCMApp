using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCMApp.Models
{
    public class ViewModelQuestionnaireElements
    {
        public string intituleQuestionnaire { get; set; }
        public int idQuestionnaire { get; set; }
        public List<Elements> elements { get; set; }
        public Questionnaires questionnaire { get; internal set; }
    }
}