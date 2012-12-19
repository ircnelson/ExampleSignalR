//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExampleSignalR.Contexto.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pessoa
    {
        public Pessoa()
        {
            this.Pessoa1 = new HashSet<Pessoa>();
            this.Pessoa11 = new HashSet<Pessoa>();
        }
    
        public string CDPessoa { get; set; }
        public string CDUnidServ { get; set; }
        public System.DateTime DataCad { get; set; }
        public string Tipo { get; set; }
        public string NMPessoa { get; set; }
        public string NomeFant { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public Nullable<short> CDNivel { get; set; }
        public Nullable<short> CDOperador { get; set; }
        public string Sexo { get; set; }
        public Nullable<System.DateTime> DataNasc { get; set; }
        public string Cargo { get; set; }
        public Nullable<decimal> Salario { get; set; }
        public string CartTrab { get; set; }
        public string SerieCTPS { get; set; }
        public string UFCTPS { get; set; }
        public string CidadeNasc { get; set; }
        public string UFNasc { get; set; }
        public string PaisNasc { get; set; }
        public Nullable<short> CDGrauDep { get; set; }
        public Nullable<short> CDEstCivil { get; set; }
        public string CPFCNPJ { get; set; }
        public string RG { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string NomeResp { get; set; }
        public string CargoResp { get; set; }
        public string Email { get; set; }
        public string NomeContato { get; set; }
        public string FoneRes { get; set; }
        public string FoneCel { get; set; }
        public string FoneCom { get; set; }
        public string FoneCnt { get; set; }
        public string FoneFax { get; set; }
        public Nullable<bool> Sesi { get; set; }
        public string NumRegPrf { get; set; }
        public Nullable<System.DateTime> DataAdm { get; set; }
        public Nullable<System.DateTime> DataDem { get; set; }
        public string TipoHor { get; set; }
        public string CDTitular { get; set; }
        public string Situacao { get; set; }
        public string CDEmpresa { get; set; }
        public string InscrEst { get; set; }
        public string InscrMunic { get; set; }
        public string CaixaPostal { get; set; }
        public string CDCnae { get; set; }
        public Nullable<short> CDCategoria { get; set; }
        public string TpRecolhim { get; set; }
        public Nullable<short> NumFunc { get; set; }
        public string CEI { get; set; }
        public Nullable<short> CDGrauEsc { get; set; }
        public string CursoFormacao { get; set; }
        public string Obs { get; set; }
        public Nullable<bool> Ativo { get; set; }
        public Nullable<bool> EhCliente { get; set; }
        public Nullable<bool> EhEmpresa { get; set; }
        public Nullable<bool> EhFornec { get; set; }
        public Nullable<bool> EhParceiro { get; set; }
        public Nullable<bool> EhColaborador { get; set; }
        public Nullable<short> CDSitEspec { get; set; }
        public string PIS { get; set; }
        public string CDCBO { get; set; }
        public string RGOrgao { get; set; }
        public string RGUF { get; set; }
        public Nullable<bool> EhAssessoriaCob { get; set; }
        public Nullable<bool> EhProfissional { get; set; }
        public Nullable<short> CDClassifica { get; set; }
        public string Habilitacao { get; set; }
        public string Apelido { get; set; }
        public string TitProf { get; set; }
        public Nullable<short> CargaHora { get; set; }
        public Nullable<short> CDOperadorAlt { get; set; }
        public Nullable<System.DateTime> DtaAlt { get; set; }
        public string ModCad { get; set; }
        public string ModAlt { get; set; }
        public string ChvValReg { get; set; }
        public bool IncPz { get; set; }
        public Nullable<bool> EhEtrg { get; set; }
        public string EtrgNatu { get; set; }
        public Nullable<bool> CnvOdt { get; set; }
        public string NMRefPes { get; set; }
        public string FoneRefPes { get; set; }
        public string NMRefCom { get; set; }
        public string FoneRefCom { get; set; }
        public string InscrEstSubst { get; set; }
    
        public virtual ICollection<Pessoa> Pessoa1 { get; set; }
        public virtual Pessoa Pessoa2 { get; set; }
        public virtual ICollection<Pessoa> Pessoa11 { get; set; }
        public virtual Pessoa Pessoa3 { get; set; }
        public virtual UnidServ UnidServ { get; set; }
    }
}