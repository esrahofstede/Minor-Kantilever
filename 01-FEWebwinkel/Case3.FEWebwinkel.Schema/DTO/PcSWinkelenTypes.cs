﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-pcswinkelen:v1:messages", ClrNamespace="Case3.PcSWinkelen.Messages")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-pcswinkelen:v1:schema", ClrNamespace="Case3.PcSWinkelen.Schema")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:schemas-www-kantilever-nl:bscatalogusbeheer:product:v1", ClrNamespace="Case3.BSCatalogusBeheer.Schema.Product")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:schemas-www-kantilever-nl:bscatalogusbeheer:categorie:v1", ClrNamespace="Case3.BSCatalogusBeheer.Schema.Categorie")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-common:v1:faults", ClrNamespace="case3common.v1.faults")]

namespace Case3.PcSWinkelen.Messages
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FindCatalogusRequestMessage", Namespace="urn:case3-pcswinkelen:v1:messages")]
    public partial class FindCatalogusRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NaamFilterField;
        
        private string BeschrijvingFilterField;
        
        private System.Nullable<decimal> MinimumPrijsField;
        
        private System.Nullable<decimal> MaximumPrijsField;
        
        private System.Nullable<int> CategorieField;
        
        private System.Nullable<int> LeverancierField;
        
        private bool AlleenLeverbareProductenField;
        
        private int PageField;
        
        private int PageSizeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NaamFilter
        {
            get
            {
                return this.NaamFilterField;
            }
            set
            {
                this.NaamFilterField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string BeschrijvingFilter
        {
            get
            {
                return this.BeschrijvingFilterField;
            }
            set
            {
                this.BeschrijvingFilterField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.Nullable<decimal> MinimumPrijs
        {
            get
            {
                return this.MinimumPrijsField;
            }
            set
            {
                this.MinimumPrijsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public System.Nullable<decimal> MaximumPrijs
        {
            get
            {
                return this.MaximumPrijsField;
            }
            set
            {
                this.MaximumPrijsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public System.Nullable<int> Categorie
        {
            get
            {
                return this.CategorieField;
            }
            set
            {
                this.CategorieField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public System.Nullable<int> Leverancier
        {
            get
            {
                return this.LeverancierField;
            }
            set
            {
                this.LeverancierField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public bool AlleenLeverbareProducten
        {
            get
            {
                return this.AlleenLeverbareProductenField;
            }
            set
            {
                this.AlleenLeverbareProductenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public int Page
        {
            get
            {
                return this.PageField;
            }
            set
            {
                this.PageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public int PageSize
        {
            get
            {
                return this.PageSizeField;
            }
            set
            {
                this.PageSizeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FindCatalogusResponseMessage", Namespace="urn:case3-pcswinkelen:v1:messages")]
    public partial class FindCatalogusResponseMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.PcSWinkelen.Schema.CatalogusCollection ProductsField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public Case3.PcSWinkelen.Schema.CatalogusCollection Products
        {
            get
            {
                return this.ProductsField;
            }
            set
            {
                this.ProductsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddItemToWinkelmandRequestMessage", Namespace="urn:case3-pcswinkelen:v1:messages")]
    public partial class AddItemToWinkelmandRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.PcSWinkelen.Schema.WinkelmandjeItemRef WinkelmandjeItemRefField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public Case3.PcSWinkelen.Schema.WinkelmandjeItemRef WinkelmandjeItemRef
        {
            get
            {
                return this.WinkelmandjeItemRefField;
            }
            set
            {
                this.WinkelmandjeItemRefField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AddItemToWinkelmandResponseMessage", Namespace="urn:case3-pcswinkelen:v1:messages")]
    public partial class AddItemToWinkelmandResponseMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private bool SucceededField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public bool Succeeded
        {
            get
            {
                return this.SucceededField;
            }
            set
            {
                this.SucceededField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetWinkelmandRequestMessage", Namespace="urn:case3-pcswinkelen:v1:messages")]
    public partial class GetWinkelmandRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string SessieIdField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string SessieId
        {
            get
            {
                return this.SessieIdField;
            }
            set
            {
                this.SessieIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetWinkelmandResponseMessage", Namespace="urn:case3-pcswinkelen:v1:messages")]
    public partial class GetWinkelmandResponseMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.PcSWinkelen.Schema.WinkelMandCollection WinkelmandCollectionField;
        
        private string SessieIdField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public Case3.PcSWinkelen.Schema.WinkelMandCollection WinkelmandCollection
        {
            get
            {
                return this.WinkelmandCollectionField;
            }
            set
            {
                this.WinkelmandCollectionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=1)]
        public string SessieId
        {
            get
            {
                return this.SessieIdField;
            }
            set
            {
                this.SessieIdField = value;
            }
        }
    }
}
namespace Case3.PcSWinkelen.Schema
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="CatalogusCollection", Namespace="urn:case3-pcswinkelen:v1:schema", ItemName="CatalogusItem")]
    public class CatalogusCollection : System.Collections.Generic.List<Case3.PcSWinkelen.Schema.CatalogusProductItem>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CatalogusProductItem", Namespace="urn:case3-pcswinkelen:v1:schema")]
    public partial class CatalogusProductItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.BSCatalogusBeheer.Schema.Product.Product ProductField;
        
        private int VoorraadField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public Case3.BSCatalogusBeheer.Schema.Product.Product Product
        {
            get
            {
                return this.ProductField;
            }
            set
            {
                this.ProductField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Voorraad
        {
            get
            {
                return this.VoorraadField;
            }
            set
            {
                this.VoorraadField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WinkelmandjeItemRef", Namespace="urn:case3-pcswinkelen:v1:schema")]
    public partial class WinkelmandjeItemRef : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ProductIdField;
        
        private string SessieIdField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ProductId
        {
            get
            {
                return this.ProductIdField;
            }
            set
            {
                this.ProductIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string SessieId
        {
            get
            {
                return this.SessieIdField;
            }
            set
            {
                this.SessieIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="WinkelMandCollection", Namespace="urn:case3-pcswinkelen:v1:schema", ItemName="WinkelmandjeItem")]
    public class WinkelMandCollection : System.Collections.Generic.List<Case3.PcSWinkelen.Schema.WinkelmandjeItem>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WinkelmandjeItem", Namespace="urn:case3-pcswinkelen:v1:schema")]
    public partial class WinkelmandjeItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.BSCatalogusBeheer.Schema.Product.Product ProductField;
        
        private int AantalField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public Case3.BSCatalogusBeheer.Schema.Product.Product Product
        {
            get
            {
                return this.ProductField;
            }
            set
            {
                this.ProductField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int Aantal
        {
            get
            {
                return this.AantalField;
            }
            set
            {
                this.AantalField = value;
            }
        }
    }
}
namespace Case3.BSCatalogusBeheer.Schema.Product
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="urn:schemas-www-kantilever-nl:bscatalogusbeheer:product:v1")]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Nullable<int> IdField;
        
        private string AfbeeldingURLField;
        
        private string BeschrijvingField;
        
        private string LeverancierNaamField;
        
        private string LeveranciersProductIdField;
        
        private System.Nullable<System.DateTime> LeverbaarTotField;
        
        private System.Nullable<System.DateTime> LeverbaarVanafField;
        
        private string NaamField;
        
        private System.Nullable<decimal> PrijsField;
        
        private Case3.BSCatalogusBeheer.Schema.Categorie.CategorieCollection CategorieLijstField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string AfbeeldingURL
        {
            get
            {
                return this.AfbeeldingURLField;
            }
            set
            {
                this.AfbeeldingURLField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string Beschrijving
        {
            get
            {
                return this.BeschrijvingField;
            }
            set
            {
                this.BeschrijvingField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=3)]
        public string LeverancierNaam
        {
            get
            {
                return this.LeverancierNaamField;
            }
            set
            {
                this.LeverancierNaamField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=4)]
        public string LeveranciersProductId
        {
            get
            {
                return this.LeveranciersProductIdField;
            }
            set
            {
                this.LeveranciersProductIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public System.Nullable<System.DateTime> LeverbaarTot
        {
            get
            {
                return this.LeverbaarTotField;
            }
            set
            {
                this.LeverbaarTotField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public System.Nullable<System.DateTime> LeverbaarVanaf
        {
            get
            {
                return this.LeverbaarVanafField;
            }
            set
            {
                this.LeverbaarVanafField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public string Naam
        {
            get
            {
                return this.NaamField;
            }
            set
            {
                this.NaamField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public System.Nullable<decimal> Prijs
        {
            get
            {
                return this.PrijsField;
            }
            set
            {
                this.PrijsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=9)]
        public Case3.BSCatalogusBeheer.Schema.Categorie.CategorieCollection CategorieLijst
        {
            get
            {
                return this.CategorieLijstField;
            }
            set
            {
                this.CategorieLijstField = value;
            }
        }
    }
}
namespace Case3.BSCatalogusBeheer.Schema.Categorie
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="CategorieCollection", Namespace="urn:schemas-www-kantilever-nl:bscatalogusbeheer:categorie:v1", ItemName="Categorie")]
    public class CategorieCollection : System.Collections.Generic.List<Case3.BSCatalogusBeheer.Schema.Categorie.Categorie>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Categorie", Namespace="urn:schemas-www-kantilever-nl:bscatalogusbeheer:categorie:v1")]
    public partial class Categorie : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Nullable<int> IdField;
        
        private string NaamField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Naam
        {
            get
            {
                return this.NaamField;
            }
            set
            {
                this.NaamField = value;
            }
        }
    }
}
namespace case3common.v1.faults
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="FunctionalErrorList", Namespace="urn:case3-common:v1:faults", ItemName="FunctionalErrorDetail")]
    public class FunctionalErrorList : System.Collections.Generic.List<case3common.v1.faults.FunctionalErrorDetail>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FunctionalErrorDetail", Namespace="urn:case3-common:v1:faults")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(case3common.v1.faults.FunctionalErrorList))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Messages.FindCatalogusRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Messages.FindCatalogusResponseMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Messages.AddItemToWinkelmandRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Messages.AddItemToWinkelmandResponseMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Messages.GetWinkelmandRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Messages.GetWinkelmandResponseMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Schema.CatalogusCollection))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Schema.CatalogusProductItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Schema.WinkelmandjeItemRef))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Schema.WinkelMandCollection))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Schema.WinkelmandjeItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSCatalogusBeheer.Schema.Categorie.CategorieCollection))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSCatalogusBeheer.Schema.Categorie.Categorie))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSCatalogusBeheer.Schema.Product.Product))]
    public partial class FunctionalErrorDetail : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ErrorCodeField;
        
        private string MessageField;
        
        private object DataField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ErrorCode
        {
            get
            {
                return this.ErrorCodeField;
            }
            set
            {
                this.ErrorCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
        public object Data
        {
            get
            {
                return this.DataField;
            }
            set
            {
                this.DataField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IPcSWinkelenService")]
public interface IPcSWinkelenService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPcSWinkelenService/GetCatalogusItems", ReplyAction="http://tempuri.org/IPcSWinkelenService/GetCatalogusItemsResponse")]
    [System.ServiceModel.FaultContractAttribute(typeof(case3common.v1.faults.FunctionalErrorList), Action="http://tempuri.org/IPcSWinkelenService/GetCatalogusItemsFunctionalErrorListFault", Name="FunctionalErrorList", Namespace="urn:case3-common:v1:faults")]
    Case3.PcSWinkelen.Messages.FindCatalogusResponseMessage GetCatalogusItems(Case3.PcSWinkelen.Messages.FindCatalogusRequestMessage request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPcSWinkelenService/GetCatalogusItems", ReplyAction="http://tempuri.org/IPcSWinkelenService/GetCatalogusItemsResponse")]
    System.Threading.Tasks.Task<Case3.PcSWinkelen.Messages.FindCatalogusResponseMessage> GetCatalogusItemsAsync(Case3.PcSWinkelen.Messages.FindCatalogusRequestMessage request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPcSWinkelenService/AddProductToWinkelmand", ReplyAction="http://tempuri.org/IPcSWinkelenService/AddProductToWinkelmandResponse")]
    Case3.PcSWinkelen.Messages.AddItemToWinkelmandResponseMessage AddProductToWinkelmand(Case3.PcSWinkelen.Messages.AddItemToWinkelmandRequestMessage request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPcSWinkelenService/AddProductToWinkelmand", ReplyAction="http://tempuri.org/IPcSWinkelenService/AddProductToWinkelmandResponse")]
    System.Threading.Tasks.Task<Case3.PcSWinkelen.Messages.AddItemToWinkelmandResponseMessage> AddProductToWinkelmandAsync(Case3.PcSWinkelen.Messages.AddItemToWinkelmandRequestMessage request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPcSWinkelenService/GetWinkelmand", ReplyAction="http://tempuri.org/IPcSWinkelenService/GetWinkelmandResponse")]
    Case3.PcSWinkelen.Messages.GetWinkelmandResponseMessage GetWinkelmand(Case3.PcSWinkelen.Messages.GetWinkelmandRequestMessage request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPcSWinkelenService/GetWinkelmand", ReplyAction="http://tempuri.org/IPcSWinkelenService/GetWinkelmandResponse")]
    System.Threading.Tasks.Task<Case3.PcSWinkelen.Messages.GetWinkelmandResponseMessage> GetWinkelmandAsync(Case3.PcSWinkelen.Messages.GetWinkelmandRequestMessage request);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IPcSWinkelenServiceChannel : IPcSWinkelenService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class PcSWinkelenServiceClient : System.ServiceModel.ClientBase<IPcSWinkelenService>, IPcSWinkelenService
{
    
    public PcSWinkelenServiceClient()
    {
    }
    
    public PcSWinkelenServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public PcSWinkelenServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PcSWinkelenServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PcSWinkelenServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public Case3.PcSWinkelen.Messages.FindCatalogusResponseMessage GetCatalogusItems(Case3.PcSWinkelen.Messages.FindCatalogusRequestMessage request)
    {
        return base.Channel.GetCatalogusItems(request);
    }
    
    public System.Threading.Tasks.Task<Case3.PcSWinkelen.Messages.FindCatalogusResponseMessage> GetCatalogusItemsAsync(Case3.PcSWinkelen.Messages.FindCatalogusRequestMessage request)
    {
        return base.Channel.GetCatalogusItemsAsync(request);
    }
    
    public Case3.PcSWinkelen.Messages.AddItemToWinkelmandResponseMessage AddProductToWinkelmand(Case3.PcSWinkelen.Messages.AddItemToWinkelmandRequestMessage request)
    {
        return base.Channel.AddProductToWinkelmand(request);
    }
    
    public System.Threading.Tasks.Task<Case3.PcSWinkelen.Messages.AddItemToWinkelmandResponseMessage> AddProductToWinkelmandAsync(Case3.PcSWinkelen.Messages.AddItemToWinkelmandRequestMessage request)
    {
        return base.Channel.AddProductToWinkelmandAsync(request);
    }
    
    public Case3.PcSWinkelen.Messages.GetWinkelmandResponseMessage GetWinkelmand(Case3.PcSWinkelen.Messages.GetWinkelmandRequestMessage request)
    {
        return base.Channel.GetWinkelmand(request);
    }
    
    public System.Threading.Tasks.Task<Case3.PcSWinkelen.Messages.GetWinkelmandResponseMessage> GetWinkelmandAsync(Case3.PcSWinkelen.Messages.GetWinkelmandRequestMessage request)
    {
        return base.Channel.GetWinkelmandAsync(request);
    }
}
