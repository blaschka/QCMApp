using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QCMApp.bll
{
    public class ElementManager
    {
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
        public void FindById(Elements element)
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
    }
}