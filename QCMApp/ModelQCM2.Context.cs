﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QCMApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QCMAppBDDEntities : DbContext
    {
        public QCMAppBDDEntities()
            : base("name=QCMAppBDDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Choixes> Choixes { get; set; }
        public virtual DbSet<Elements> Elements { get; set; }
        public virtual DbSet<GroupeSiteQuestionnaire> GroupeSiteQuestionnaire { get; set; }
        public virtual DbSet<Questionnaires> Questionnaires { get; set; }
        public virtual DbSet<Reponses> Reponses { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeElements> TypeElements { get; set; }
        public virtual DbSet<Utilisateurs> Utilisateurs { get; set; }
    }
}
