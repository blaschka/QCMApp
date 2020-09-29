using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        public List<Elements> SelectAllFromQuestionnaire(int id)
        {

                Questionnaires questionnaire = new Questionnaires();
                using (var context = new QCMAppBDDEntities())
                {
                    try
                    {

                    //questionnaire.Elements = context.Elements.Where(e=>e.questionnaire_id == id).Select(e=>e).ToList();
                    questionnaire.Elements = context.Elements.Where(e => e.questionnaire_id == id)
                        .Select(e => e)
                        .OrderBy(e => e.ordre)
                        .ToList();


                }
                    catch (Exception e)
                    {

                        throw;
                    }

                }
                return (List<Elements>)questionnaire.Elements;
        }
        public void DeleteElement(int id)
        {
            Tools.Logger.Ecrire(Tools.Logger.Niveau.Info, string.Format("Debut DeleteElement({0})", id));
            using (var context = new QCMAppBDDEntities())
            {
                var element = context.Elements.Find(id);
                try
                {
                    int ordre = (int)element.ordre;
                    int idQuestionnaire = (int)element.questionnaire_id;
                    context.Elements.Remove(element);               
                    context.SaveChanges();
                    elementsApresReorder(ordre,idQuestionnaire);
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }

        public void UpdateElement(Elements element)
        {
            using (var context = new QCMAppBDDEntities())
            {
                try
                {
                    context.Elements.AddOrUpdate(element);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        public void UpdateListeElements(List<Elements> elements)
        {
            using (var context = new QCMAppBDDEntities())
            {
                try
                {
                    //context.Questionnaires.AddOrUpdate(elements);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
        public void elementUp(int idElement)
        {
            Elements element = FindById(idElement);
            Elements elementAvant = elementOrdreAvant(element);
            int ordreElementOrigin = (int)element.ordre;
            element.ordre = elementAvant.ordre;
            elementAvant.ordre = ordreElementOrigin;
            UpdateElement(element);
            UpdateElement(elementAvant);

            
        }
        public void elementDown(int idElement)
        {
            Elements element = FindById(idElement);
            Elements elementApres = elementOrdreApres(element);
            int ordreElementOrigin = (int)element.ordre;
            element.ordre = elementApres.ordre;
            elementApres.ordre = ordreElementOrigin;
            UpdateElement(element);
            UpdateElement(elementApres);
        }
        public Elements elementOrdreAvant(Elements element)
        {
            Elements elementAvant = new Elements();
            using (var context = new QCMAppBDDEntities())
            {
                elementAvant = context.Elements.Where(e => e.ordre < element.ordre && e.questionnaire_id == element.questionnaire_id)
                    .Select(e => e).OrderByDescending(e => e.ordre)
                    .FirstOrDefault();

            }
            return elementAvant;
        }
        public Elements elementOrdreApres(Elements element)
        {
            Elements elementApres = new Elements();
            using (var context = new QCMAppBDDEntities())
            {
                elementApres = context.Elements.Where(e => e.ordre > element.ordre && e.questionnaire_id == element.questionnaire_id)
                    .Select(e => e).OrderBy(e => e.ordre)
                    .FirstOrDefault();

            }
            return elementApres;
        }
        public void elementsApresReorder(int suprimElement,int idQuestionnaire)
        {
            
            using (var context = new QCMAppBDDEntities())
            {
                List<Elements> elements = context.Elements.Where(e => e.ordre > suprimElement && e.questionnaire_id == idQuestionnaire)
                    .Select(e => e).OrderBy(e => e.ordre)
                    .ToList();

                foreach (var item in elements)
                {
                    item.ordre = suprimElement;
                    UpdateElement(item);
                    suprimElement++;
                }
            }


           
        }
    }

}