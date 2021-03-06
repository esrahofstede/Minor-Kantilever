﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:schemas-www-kantilever-nl:bscatalogusbeheer:product:v1", ClrNamespace="Case3.BSCatalogusBeheer.Schema.ProductNS")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:schemas-www-kantilever-nl:bscatalogusbeheer:categorie:v1", ClrNamespace="Case3.BSCatalogusBeheer.Schema.CategorieNS")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-common:v1:faults", ClrNamespace="Case3.Common.Faults")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-bsbestellingenbeheer:v1:schema", ClrNamespace="Case3.BSBestellingenbeheer.V1.Schema")]
[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("urn:case3-bsbestellingenbeheer:v1:messages", ClrNamespace="Case3.BSBestellingenbeheer.V1.Messages")]

namespace Case3.BSCatalogusBeheer.Schema.ProductNS
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
    }
}
namespace Case3.BSCatalogusBeheer.Schema.CategorieNS
{
    using System.Runtime.Serialization;
    
    
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
namespace Case3.Common.Faults
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ErrorDetail", Namespace="urn:case3-common:v1:faults")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSCatalogusBeheer.Schema.ProductNS.Product))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSCatalogusBeheer.Schema.CategorieNS.Categorie))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.Common.Faults.ErrorLijst))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Schema.Bestelling))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Schema.BestelItem))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Schema.Klantgegevens))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Schema.Artikelen))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Messages.FindFirstBestellingRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Messages.FindFirstBestellingResultMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Messages.InsertBestellingRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Messages.InsertBestellingResultMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusRequestMessage))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Case3.BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusResultMessage))]
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
    public class ErrorLijst : System.Collections.Generic.List<Case3.Common.Faults.ErrorDetail>
    {
    }
}
namespace Case3.BSBestellingenbeheer.V1.Schema
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Bestelling", Namespace="urn:case3-bsbestellingenbeheer:v1:schema")]
    public partial class Bestelling : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Nullable<int> BestellingIDField;
        
        private System.Nullable<int> FactuurIDField;
        
        private string FactuurDatumField;
        
        private Case3.BSBestellingenbeheer.V1.Schema.Artikelen ArtikelenField;
        
        private System.Nullable<int> StatusField;
        
        private Case3.BSBestellingenbeheer.V1.Schema.Klantgegevens KlantgegevensField;
        
        private System.Nullable<int> BTWPercentageField;
        
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
        public System.Nullable<int> BestellingID
        {
            get
            {
                return this.BestellingIDField;
            }
            set
            {
                this.BestellingIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Nullable<int> FactuurID
        {
            get
            {
                return this.FactuurIDField;
            }
            set
            {
                this.FactuurIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=2)]
        public string FactuurDatum
        {
            get
            {
                return this.FactuurDatumField;
            }
            set
            {
                this.FactuurDatumField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public Case3.BSBestellingenbeheer.V1.Schema.Artikelen Artikelen
        {
            get
            {
                return this.ArtikelenField;
            }
            set
            {
                this.ArtikelenField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=4)]
        public System.Nullable<int> Status
        {
            get
            {
                return this.StatusField;
            }
            set
            {
                this.StatusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public Case3.BSBestellingenbeheer.V1.Schema.Klantgegevens Klantgegevens
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=6)]
        public System.Nullable<int> BTWPercentage
        {
            get
            {
                return this.BTWPercentageField;
            }
            set
            {
                this.BTWPercentageField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BestelItem", Namespace="urn:case3-bsbestellingenbeheer:v1:schema")]
    public partial class BestelItem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.BSCatalogusBeheer.Schema.ProductNS.Product ProductField;
        
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
        public Case3.BSCatalogusBeheer.Schema.ProductNS.Product Product
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Klantgegevens", Namespace="urn:case3-bsbestellingenbeheer:v1:schema")]
    public partial class Klantgegevens : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string NaamField;
        
        private string Adresregel1Field;
        
        private string Adresregel2Field;
        
        private string PostcodeField;
        
        private string WoonplaatsField;
        
        private string TelefoonnummerField;
        
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
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=5)]
        public string Telefoonnummer
        {
            get
            {
                return this.TelefoonnummerField;
            }
            set
            {
                this.TelefoonnummerField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="Artikelen", Namespace="urn:case3-bsbestellingenbeheer:v1:schema", ItemName="ArtikelItem")]
    public class Artikelen : System.Collections.Generic.List<Case3.BSBestellingenbeheer.V1.Schema.BestelItem>
    {
    }
}
namespace Case3.BSBestellingenbeheer.V1.Messages
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FindFirstBestellingRequestMessage", Namespace="urn:case3-bsbestellingenbeheer:v1:messages")]
    public partial class FindFirstBestellingRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FindFirstBestellingResultMessage", Namespace="urn:case3-bsbestellingenbeheer:v1:messages")]
    public partial class FindFirstBestellingResultMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.BSBestellingenbeheer.V1.Schema.Bestelling BestellingOpdrachtField;
        
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
        public Case3.BSBestellingenbeheer.V1.Schema.Bestelling BestellingOpdracht
        {
            get
            {
                return this.BestellingOpdrachtField;
            }
            set
            {
                this.BestellingOpdrachtField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InsertBestellingRequestMessage", Namespace="urn:case3-bsbestellingenbeheer:v1:messages")]
    public partial class InsertBestellingRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Case3.BSBestellingenbeheer.V1.Schema.Bestelling BestellingField;
        
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
        public Case3.BSBestellingenbeheer.V1.Schema.Bestelling Bestelling
        {
            get
            {
                return this.BestellingField;
            }
            set
            {
                this.BestellingField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InsertBestellingResultMessage", Namespace="urn:case3-bsbestellingenbeheer:v1:messages")]
    public partial class InsertBestellingResultMessage : object, System.Runtime.Serialization.IExtensibleDataObject
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateBestellingStatusRequestMessage", Namespace="urn:case3-bsbestellingenbeheer:v1:messages")]
    public partial class UpdateBestellingStatusRequestMessage : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private long BestellingIDField;
        
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
        public long BestellingID
        {
            get
            {
                return this.BestellingIDField;
            }
            set
            {
                this.BestellingIDField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateBestellingStatusResultMessage", Namespace="urn:case3-bsbestellingenbeheer:v1:messages")]
    public partial class UpdateBestellingStatusResultMessage : object, System.Runtime.Serialization.IExtensibleDataObject
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
