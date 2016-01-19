﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-pcswinkelen:v1:schema", ClrNamespace="Case3.PcSWinkelen.SchemaNS")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-pcswinkelen:v1:messages", ClrNamespace="Case3.PcSWinkelen.MessagesNS")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-common:v1:faults", ClrNamespace="case3common.v1.faults")]

namespace Case3.PcSWinkelen.SchemaNS
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CatalogusProductItem", Namespace="urn:case3-pcswinkelen:v1:schema")]
    public partial class CatalogusProductItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.PcSWinkelen.Schema.ProductNS.Product ProductField;
        
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
        public Case3.PcSWinkelen.Schema.ProductNS.Product Product
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
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="CatalogusCollection", Namespace="urn:case3-pcswinkelen:v1:schema", ItemName="CatalogusItem")]
    public class CatalogusCollection : System.Collections.Generic.List<Case3.PcSWinkelen.SchemaNS.CatalogusProductItem>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WinkelmandItemRef", Namespace="urn:case3-pcswinkelen:v1:schema")]
    public partial class WinkelmandItemRef : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int ProductIdField;
        
        private int AantalField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=2)]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="WinkelmandItem", Namespace="urn:case3-pcswinkelen:v1:schema")]
    public partial class WinkelmandItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.PcSWinkelen.Schema.ProductNS.Product ProductField;
        
        private int AantalField;
        
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
        public Case3.PcSWinkelen.Schema.ProductNS.Product Product
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
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
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
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="WinkelMandCollection", Namespace="urn:case3-pcswinkelen:v1:schema", ItemName="WinkelmandItem")]
    public class WinkelMandCollection : System.Collections.Generic.List<Case3.PcSWinkelen.SchemaNS.WinkelmandItem>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="KlantgegevensPcS", Namespace="urn:case3-pcswinkelen:v1:schema")]
    public partial class KlantgegevensPcS : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NaamField;
        
        private string Adresregel1Field;
        
        private string Adresregel2Field;
        
        private string PostcodeField;
        
        private string WoonplaatsField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public string Adresregel1
        {
            get
            {
                return this.Adresregel1Field;
            }
            set
            {
                this.Adresregel1Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string Adresregel2
        {
            get
            {
                return this.Adresregel2Field;
            }
            set
            {
                this.Adresregel2Field = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public string Postcode
        {
            get
            {
                return this.PostcodeField;
            }
            set
            {
                this.PostcodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public string Woonplaats
        {
            get
            {
                return this.WoonplaatsField;
            }
            set
            {
                this.WoonplaatsField = value;
            }
        }
    }
}
namespace Case3.PcSWinkelen.MessagesNS
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
        
        private Case3.PcSWinkelen.SchemaNS.CatalogusCollection ProductsField;
        
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
        public Case3.PcSWinkelen.SchemaNS.CatalogusCollection Products
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
        
        private Case3.PcSWinkelen.SchemaNS.WinkelmandItemRef WinkelmandItemRefField;
        
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
        public Case3.PcSWinkelen.SchemaNS.WinkelmandItemRef WinkelmandItemRef
        {
            get
            {
                return this.WinkelmandItemRefField;
            }
            set
            {
                this.WinkelmandItemRefField = value;
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
        
        private Case3.PcSWinkelen.SchemaNS.WinkelMandCollection WinkelmandCollectionField;
        
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
        public Case3.PcSWinkelen.SchemaNS.WinkelMandCollection WinkelmandCollection
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WinkelmandBestellenRequestMessage", Namespace="urn:case3-pcswinkelen:v1:messages")]
    public partial class WinkelmandBestellenRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string SessieIdField;
        
        private Case3.PcSWinkelen.SchemaNS.KlantgegevensPcS KlantgegevensField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false, Order=1)]
        public Case3.PcSWinkelen.SchemaNS.KlantgegevensPcS Klantgegevens
        {
            get
            {
                return this.KlantgegevensField;
            }
            set
            {
                this.KlantgegevensField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WinkelmandBestellenResponseMessage", Namespace="urn:case3-pcswinkelen:v1:messages")]
    public partial class WinkelmandBestellenResponseMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
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
    }
}
namespace case3common.v1.faults
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ErrorDetail", Namespace="urn:case3-common:v1:faults")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Schema.ProductNS.Product))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.Schema.CategorieNS.Categorie))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.SchemaNS.CatalogusProductItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.SchemaNS.CatalogusCollection))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.SchemaNS.WinkelmandItemRef))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.SchemaNS.WinkelmandItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.SchemaNS.WinkelMandCollection))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.SchemaNS.KlantgegevensPcS))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.MessagesNS.FindCatalogusRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.MessagesNS.FindCatalogusResponseMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.MessagesNS.AddItemToWinkelmandRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.MessagesNS.AddItemToWinkelmandResponseMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.MessagesNS.GetWinkelmandRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.MessagesNS.GetWinkelmandResponseMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.MessagesNS.WinkelmandBestellenRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.PcSWinkelen.MessagesNS.WinkelmandBestellenResponseMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(case3common.v1.faults.ErrorLijst))]
    public partial class ErrorDetail : object, System.Runtime.Serialization.IExtensibleDataObject
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ErrorLijst", Namespace="urn:case3-common:v1:faults", ItemName="ErrorDetail")]
    public class ErrorLijst : System.Collections.Generic.List<case3common.v1.faults.ErrorDetail>
    {
    }
}
