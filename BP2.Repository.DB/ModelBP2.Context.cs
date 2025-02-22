﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BP2.Repository.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ModelBP2Container : DbContext
    {
        public ModelBP2Container()
            : base("name=ModelBP2Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TuristickaAgencija> TuristickaAgencijaSet { get; set; }
        public virtual DbSet<Filijala> FilijalaSet { get; set; }
        public virtual DbSet<Putovanje> PutovanjeSet { get; set; }
        public virtual DbSet<Klijent> KlijentSet { get; set; }
        public virtual DbSet<Cenovnik> CenovnikSet { get; set; }
        public virtual DbSet<CenovnikKojiTuristickaAgencijaFormira> CenovnikKojiTuristickaAgencijaFormiraSet { get; set; }
        public virtual DbSet<KlijentKojiPoslujeSaFilijalom> KlijentKojiPoslujeSaFilijalomSet { get; set; }
        public virtual DbSet<PutovanjeKojeNudiTuristickaAgencija> PutovanjeKojeTuristickaAgencijaNudiSet { get; set; }
        public virtual DbSet<Ugovor> UgovorSet { get; set; }
        public virtual DbSet<Cenovnik_Putovanje> Cenovnik_Putovanje { get; set; }
        public virtual DbSet<Radnik> RadnikSet { get; set; }
    
        [DbFunction("ModelBP2Container", "AllVodicsPutovanja")]
        public virtual IQueryable<AllVodicsPutovanja_Result> AllVodicsPutovanja(Nullable<int> vodicId)
        {
            var vodicIdParameter = vodicId.HasValue ?
                new ObjectParameter("vodicId", vodicId) :
                new ObjectParameter("vodicId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<AllVodicsPutovanja_Result>("[ModelBP2Container].[AllVodicsPutovanja](@vodicId)", vodicIdParameter);
        }
    
        public virtual int GetVodicsPutovanja(Nullable<int> vodicId, ObjectParameter count)
        {
            var vodicIdParameter = vodicId.HasValue ?
                new ObjectParameter("vodicId", vodicId) :
                new ObjectParameter("vodicId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetVodicsPutovanja", vodicIdParameter, count);
        }
    }
}
