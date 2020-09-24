using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCMApp.bll
{
    public class ElementManager
    {
        List<Elements> listeElements = new List<Elements>();
        public void InsertElement(Elements element)
        {
            using (var context = new QCMAppBDDEntities())
            {
               
                try
                {
                    context.Elements.Add(element);
                    context.SaveChanges();
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }
        public Elements FindById(int id)
        {
            Elements element = new Elements();
            using (var context = new QCMAppBDDEntities())
            {
                

                try
                {
                    element = context.Elements.Find(id);
                    
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return element;
        }
        public List<Elements> SelectAll()
        {
            using (var context = new QCMAppBDDEntities())
            {
                listeElements = context.Elements.ToList();
            }

            return listeElements;
        }
        public List<Elements> SelectAllFromQustionnaire(int id)
        {

                Questionnaires questionnaire = new Questionnaires();
                using (var context = new QCMAppBDDEntities())
                {
                    try
                    {
                        
                        questionnaire.Elements = context.Elements.Where(e=>e.questionnaire_id == id).Select(e=>e).ToList();


                    }
                    catch (Exception e)
                    {

                        throw;
                    }

                }
                return (List<Elements>)questionnaire.Elements;
        }
    }
}